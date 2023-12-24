using Domain.ProductManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.TypeConfigurations.ProductTypeConfiguration
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Code)
                .IsUnique();

            builder.Property(x => x.Code)
                .IsRequired();

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.UnitPrice)
                .IsRequired();
        }
    }
}
