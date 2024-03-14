using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZapatillasConEstilo.Domain.interfaces;
using ZapatillasConEstilo.Infrastructure.DataAccess.Interface;
using ZapatillasConEstilo.Infrastructure.DataAccess.Repositories;
using ZapatillasConEstilo.Infrastructure.Model;

namespace ZapatillasConEstilo.Infrastructure.Extentions;

public static class InjectionExtensions
{
    public static IServiceCollection AddInjectionInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var assembly = typeof(EcommerceContext).Assembly.FullName;
        services.AddDbContext<EcommerceContext>(
            options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("POSConectionString"),
                    b => b.MigrationsAssembly(assembly)
                ),
            ServiceLifetime.Transient
        );

        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IUserRepository, UserRepository>();
        return services;
    }
}
