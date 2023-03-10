using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping_Website.Models;
namespace Shopping_Website.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x=> x.Id);   
            builder.Property(x => x.Name).HasColumnType("nvarchar(100)");
            builder.Property(x => x.Supplier).HasColumnType("nvarchar(100)");
            builder.Property(x => x.Description).HasColumnType("nvarchar(100)");
        }
    }
}
