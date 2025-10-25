// Entities/User.cs
namespace AutoPayOrganizer.API.Entities;

public sealed class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Username { get; set; } = default!;     // <— EKLE
    public string Email { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

    // İsteğe bağlı navigation'lar
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}