using AutoPayOrganizer.API.Entities;

namespace AutoPayOrganizer.API.Interfaces;

public interface IPaymentRepository
{
    Task<IEnumerable<Payment>> GetAllByUserAsync(Guid userId, CancellationToken ct = default);
    Task<Payment?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task AddAsync(Payment payment, CancellationToken ct = default);
    Task UpdateAsync(Payment payment, CancellationToken ct = default);
    Task DeleteAsync(Guid id, CancellationToken ct = default);
}