using Domain.DistributorManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.TypeConfigurations.DistributorTypeConfiguration
{
    public class DistributorTypeConfiguration : IEntityTypeConfiguration<Distributor>
    {
        public void Configure(EntityTypeBuilder<Distributor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);  
            
            builder.Property(x=> x.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.BirthDate)
                .IsRequired();

            builder.Property(x=> x.Gender)
                .IsRequired();

            builder.HasOne(x => x.IdCardInfo)
                .WithOne();

            builder.HasOne(x => x.Contact)
                .WithOne();

            builder.HasOne(x => x.Address)
                .WithOne();
        }
    }
}
