using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Builder;   
using AutoPayOrganizer.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();          
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();