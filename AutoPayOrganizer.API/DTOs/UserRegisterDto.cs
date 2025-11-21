namespace AutoPayOrganizer.API.DTOs;

public sealed record UserRegisterDto(
    string Username,
    string Email,
    string Password
);