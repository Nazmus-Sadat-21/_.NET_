using Third_Project.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add DB Context 
builder.Services.AddDbContext<AddDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/{name}", (string name) =>
{
    return Results.Ok($"Hello, {name}!");
});

app.MapControllers();

app.Run();