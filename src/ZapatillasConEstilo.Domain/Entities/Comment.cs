namespace ZapatillasConEstilo.Domain.Entities;

public partial class Comment
{
    public int Id { get; set; }

    public string Content { get; set; } = null!;

    public int UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
