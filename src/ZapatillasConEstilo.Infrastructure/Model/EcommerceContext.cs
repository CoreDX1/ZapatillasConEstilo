using Microsoft.EntityFrameworkCore;
using ZapatillasConEstilo.Domain.Entities;

namespace ZapatillasConEstilo.Infrastructure.Model;

public partial class EcommerceContext : DbContext
{
    public EcommerceContext() { }

    public EcommerceContext(DbContextOptions<EcommerceContext> options)
        : base(options) { }

    /// <summary>
    /// Gets or sets the comments.
    /// </summary>
    public DbSet<Comment> Comments { get; set; }

    /// <summary>
    /// Gets or sets the users.
    /// </summary>
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseNpgsql(
            "Server=192.168.1.190;Database=ecommerce;TrustServerCertificate=True;User id=postgres;Password=index"
        );

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EcommerceContext).Assembly);
    }
}
