using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data;

public class WebApiContext : DbContext
{
    public WebApiContext(DbContextOptions<WebApiContext> options) : base(options)
    {
        SQLitePCL.Batteries.Init();
    }

    public DbSet<ProductModel> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.Entity<ProductModel>().HasData(
            new ProductModel { Id = 1, Name = "Product 1", Price = 10.0m, Description = "Description 1" },
            new ProductModel { Id = 2, Name = "Product 2", Price = 20.0m, Description = "Description 2" },
            new ProductModel { Id = 3, Name = "Product 3", Price = 30.0m, Description = "Description 3" }
        );
    }

}