namespace WebApi.Models;

public class ProductModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? Description { get; set; }
}