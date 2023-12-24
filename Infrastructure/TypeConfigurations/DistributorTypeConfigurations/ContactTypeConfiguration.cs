using Domain.DistributorManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.TypeConfigurations.DistributorTypeConfigurations
{
    public class ContactTypeConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ContactType)
                .IsRequired();

            builder.Property(x => x.ContactInfo)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
