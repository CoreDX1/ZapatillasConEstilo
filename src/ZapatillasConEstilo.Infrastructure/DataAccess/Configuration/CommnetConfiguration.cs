using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZapatillasConEstilo.Domain.Entities;

namespace ZapatillasConEstilo.Infrastructure.DataAccess.Configuration;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(e => e.Id).HasName("comment_pkey");

        builder.ToTable("comment");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Content).HasColumnName("content");
        builder
            .Property(e => e.CreatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp without time zone")
            .HasColumnName("created_at");
        builder.Property(e => e.UserId).HasColumnName("user_id");

        builder
            .HasOne(d => d.User)
            .WithMany(p => p.Comments)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("comment_user_id_fkey");
    }
}
