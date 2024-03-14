using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZapatillasConEstilo.Domain.Entities;

namespace ZapatillasConEstilo.Infrastructure.DataAccess.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.UserId).HasName("users_pkey");

        builder.ToTable("users");

        builder.HasIndex(e => e.EmailAddress, "users_email_address_key").IsUnique();

        builder.Property(e => e.UserId).HasColumnName("user_id");
        builder
            .Property(e => e.CreatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp without time zone")
            .HasColumnName("created_at");
        builder.Property(e => e.EmailAddress).HasMaxLength(255).HasColumnName("email_address");
        builder.Property(e => e.LastName).HasMaxLength(255).HasColumnName("last_name");
        builder.Property(e => e.PasswordHash).HasColumnName("password_hash");
        builder.Property(e => e.PasswordSalt).HasMaxLength(512).HasColumnName("password_salt");
        builder.Property(e => e.PhoneNumber).HasMaxLength(255).HasColumnName("phone_number");
        builder
            .Property(e => e.Role)
            .HasMaxLength(255)
            .HasDefaultValueSql("'user'::character varying")
            .HasColumnName("role");
        builder
            .Property(e => e.UpdatedAt)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("updated_at");
        builder.Property(e => e.UserName).HasMaxLength(255).HasColumnName("user_name");
    }
}
