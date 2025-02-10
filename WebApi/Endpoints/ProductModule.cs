using Carter;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;

namespace WebApi.Endpoints
{
    public class ProductModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("api/products", async (WebApiContext context) =>
            {
                var products = await context.Products.ToListAsync().ConfigureAwait(false);
                return Results.Ok(products);
            }).WithOpenApi();
        }
    }
}