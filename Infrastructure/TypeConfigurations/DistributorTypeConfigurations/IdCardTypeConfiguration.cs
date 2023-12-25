using Domain.DistributorManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.TypeConfigurations.DistributorTypeConfigurations
{
    public class IdCardTypeConfiguration : IEntityTypeConfiguration<IdCard>
    {
        public void Configure(EntityTypeBuilder<IdCard> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdCardType)
                .IsRequired();

            builder.Property(x => x.DocSeries)
                .HasMaxLength(10);

            builder.Property(x => x.DocNum)
                .HasMaxLength(10);

            builder.Property(x => x.ReleaseDate)
                .IsRequired();

            builder.Property(x => x.ExpirationDate)
                .IsRequired();

            builder.HasIndex(x => x.IdNumber)
                .IsUnique();

            builder.Property(x => x.IdNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.IssuingAgency)
                .HasMaxLength(100);

            builder.HasOne(d => d.Distributor)
                .WithOne(a => a.IdCardInfo)
                .HasForeignKey<IdCard>(a => a.DistributorId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
