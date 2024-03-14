using ZapatillasConEstilo.Domain.interfaces;
using ZapatillasConEstilo.Infrastructure.DataAccess.Interface;
using ZapatillasConEstilo.Infrastructure.Model;

namespace ZapatillasConEstilo.Infrastructure.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly EcommerceContext _context;

    public IUserRepository User { get; }

    public UnitOfWork(EcommerceContext context, IUserRepository userRepository)
    {
        _context = context;
        User = userRepository;
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
