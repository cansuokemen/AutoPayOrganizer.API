using AutoPayOrganizer.API.Entities;

namespace AutoPayOrganizer.API.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email, CancellationToken ct = default);
    Task AddAsync(User user, CancellationToken ct = default);
}