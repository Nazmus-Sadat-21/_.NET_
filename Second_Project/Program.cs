var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();
app.UseHttpsRedirection();



app.MapGet("/", () =>
{
    var list = new[]
    {
      new { Name = "Alice", Age = 30 },
      new { Name = "Bob", Age = 25 },  
    };
    return list;
});

app.MapControllers();  // controller ke maping korar jonno
app.Run();

