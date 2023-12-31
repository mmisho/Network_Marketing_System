﻿using Domain.DistributorManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.TypeConfigurations.DistributorTypeConfigurations
{
    public class AddressTypeConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.AddressType)
                .IsRequired();

            builder.Property(x => x.AddressInfo)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(d => d.Distributor)
                .WithOne(a => a.Address)
                .HasForeignKey<Address>(a => a.DistributorId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
