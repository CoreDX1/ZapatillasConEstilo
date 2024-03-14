namespace ZapatillasConEstilo.Domain.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public byte[] PasswordHash { get; set; } = null!;

    public string PasswordSalt { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
