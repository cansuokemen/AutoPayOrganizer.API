namespace AutoPayOrganizer.API.Entities;

public sealed class Payment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = default!;
    public decimal Amount { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsPaid { get; set; } = false;

    // User ile ilişki
    public Guid UserId { get; set; }
    public User User { get; set; } = default!;
}