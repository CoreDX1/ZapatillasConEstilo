using ZapatillasConEstilo.Domain.interfaces;

namespace ZapatillasConEstilo.Infrastructure.DataAccess.Interface;

public interface IUnitOfWork : IDisposable
{
    IUserRepository User { get; }

    void SaveChanges();
    Task SaveChangesAsync();
}
