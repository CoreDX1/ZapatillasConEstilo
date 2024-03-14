using ZapatillasConEstilo.Domain.Entities;

namespace ZapatillasConEstilo.Domain.interfaces;

public interface IUserRepository
{
    Task<User> GetUserAsync(string userName, string passwordHash);
    Task<User> GetUserByIdAsync(int userId);
    Task<bool> AddUserAsync(User user);
    Task<bool> UpdateUserAsync(User user);
    Task<bool> DeleteUserAsync(int userId);
}
