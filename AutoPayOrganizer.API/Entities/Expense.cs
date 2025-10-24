namespace AutoPayOrganizer.API.Entities;

public sealed class Expense
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Category { get; set; } = default!;
    public decimal Amount { get; set; }
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

    // User ile ilişki
    public Guid UserId { get; set; }
    public User User { get; set; } = default!;
}