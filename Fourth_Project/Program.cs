using Microsoft.EntityFrameworkCore;
using Fourth_Project.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
app.UseHttpsRedirection();


app.MapGet("/", () =>
{
    return Results.Ok("Hello, World!");
});

app.MapControllers();
app.Run();

