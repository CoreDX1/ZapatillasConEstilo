using Microsoft.EntityFrameworkCore;
using ZapatillasConEstilo.Domain.Entities;
using ZapatillasConEstilo.Domain.interfaces;
using ZapatillasConEstilo.Infrastructure.Model;

namespace ZapatillasConEstilo.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly EcommerceContext _context;

    public UserRepository(EcommerceContext context)
    {
        _context = context;
    }

    public async Task<User> GetUserAsync(string userName, string password_salt)
    {
        var user = await _context
            .Users.Where(x => x.UserName == userName && x.PasswordSalt == password_salt)
            .FirstAsync();
        return user;
    }

    public async Task<User> GetUserByIdAsync(int userId)
    {
        User? user = await _context.Users.FindAsync(userId);
        return user!;
    }

    public async Task<bool> AddUserAsync(User user)
    {
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateUserAsync(User user)
    {
        _context.Update(user);
        _context.Entry(user).Property(x => x.CreatedAt).IsModified = false;
        var recordsAffected = await _context.SaveChangesAsync();
        return recordsAffected > 0;
    }

    public async Task<bool> DeleteUserAsync(int userId)
    {
        var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == userId);

        if (user == null)
            return false;

        _context.Remove(user);
        var recordsAffected = await _context.SaveChangesAsync();
        return recordsAffected > 0;
    }
}
