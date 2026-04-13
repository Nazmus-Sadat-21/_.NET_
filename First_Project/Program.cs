var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();

app.MapGet("/", () =>
{
    return "Home Page";
});

List<Product> products = new List<Product>();

// GET all products
app.MapGet("/products", () =>
{
    return Results.Ok(products);
});

// GET product by ID
app.MapGet("/products/{id:guid}", (Guid id) =>
{
    var product = products.FirstOrDefault(p => p.Id == id);

    if (product is null)
        return Results.NotFound(new { Message = $"Product with ID {id} not found." });

    return Results.Ok(product);
});

// POST - Add new product
app.MapPost("/products/add", (Product newProduct) =>
{
    var Products = new Product
    {
        Id = Guid.NewGuid(),
        Name = newProduct.Name,
        Price = newProduct.Price 
    };

    products.Add(Products);
    return Results.Created($"/products/{newProduct.Id}", newProduct);
});

// PUT - Update existing product
app.MapPut("/products/update/{id:guid}", (Guid id, Product updatedProduct) =>
{
    var existingProduct = products.FirstOrDefault(p => p.Id == id);

    if (existingProduct is null)
        return Results.NotFound(new { Message = $"Product with ID {id} not found." });

    existingProduct.Name = updatedProduct.Name;
    existingProduct.Price = updatedProduct.Price;

    return Results.Ok(existingProduct);
});

// DELETE - Remove product by ID
app.MapDelete("/products/delete/{id:guid}", (Guid id) =>
{
    var product = products.FirstOrDefault(p => p.Id == id);

    if (product is null)
        return Results.NotFound(new { Message = $"Product with ID {id} not found." });

    products.Remove(product);
    return Results.Ok(new { Message = $"Product with ID {id} deleted successfully." });
});

app.Run();

public class Product
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public double? Price { get; set; }
}