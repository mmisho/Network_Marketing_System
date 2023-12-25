using Domain.BonusManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.TypeConfigurations.BonusTypeConfiguration
{
    public class BonusTypeConfiguration : IEntityTypeConfiguration<Bonus>
    {
        public void Configure(EntityTypeBuilder<Bonus> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Distributor).WithMany();
        }
    }
}
