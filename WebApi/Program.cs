using Carter;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using WebApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddHealthChecks();
builder.Services.AddDbContext<WebApiContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCarter();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<WebApiContext>();
        context.Database.Migrate();
    }

    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "My API");
    });
    app.UseReDoc(options =>
    {
        options.SpecUrl("/openapi/v1.json");
    });

    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapHealthChecks("/health");
app.MapCarter();
app.Run();
