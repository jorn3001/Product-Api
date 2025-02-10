using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Models;

namespace WebApi.Data.Configurations;


public class ProductConfiguration : IEntityTypeConfiguration<ProductModel>
{
    public void Configure(EntityTypeBuilder<ProductModel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(x => x.Description).HasMaxLength(1024);
    }
}