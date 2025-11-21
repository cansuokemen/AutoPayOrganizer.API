using AutoPayOrganizer.API.DTOs;
using AutoPayOrganizer.API.Entities;
using AutoPayOrganizer.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;

namespace AutoPayOrganizer.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class UsersController : ControllerBase
{
    private readonly IUserRepository _users;

    public UsersController(IUserRepository users)
    {
        _users = users;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterDto dto, CancellationToken ct)
    {
        var existing = await _users.GetByEmailAsync(dto.Email, ct);
        if (existing is not null)
        {
            return BadRequest("Email already exists.");
        }

        string hash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var user = new User
        {
            Username = dto.Username,
            Email = dto.Email,
            PasswordHash = hash
        };

        await _users.AddAsync(user, ct);

        return Ok("User registered successfully.");
    }
}