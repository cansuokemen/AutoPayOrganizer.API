using AutoPayOrganizer.API.Entities;

namespace AutoPayOrganizer.API.Interfaces;

public interface IExpenseRepository
{
    Task<IEnumerable<Expense>> GetAllByUserAsync(Guid userId, CancellationToken ct = default);
    Task<Expense?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task AddAsync(Expense expense, CancellationToken ct = default);
    Task UpdateAsync(Expense expense, CancellationToken ct = default);
    Task DeleteAsync(Guid id, CancellationToken ct = default);
}