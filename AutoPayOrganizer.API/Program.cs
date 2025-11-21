using Microsoft.AspNetCore.OpenApi;
using AutoPayOrganizer.API.Data;
using AutoPayOrganizer.API.Interfaces;
using AutoPayOrganizer.API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// DI registration
builder.Services.AddScoped<IUserRepository, UserRepository>();
var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Default");
    options.UseNpgsql(connectionString);
});

var app = builder.Build();

app.MapOpenApi();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();