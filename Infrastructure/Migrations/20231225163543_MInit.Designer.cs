﻿// <auto-generated />
using System;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(EFDbContext))]
    [Migration("20231225163543_MInit")]
    partial class MInit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.BonusManagement.Bonus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("BonusAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("DistributorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DistributorId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DistributorId");

                    b.HasIndex("DistributorId1");

                    b.ToTable("Bonus");
                });

            modelBuilder.Entity("Domain.DistributorManagement.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddressInfo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("AddressType")
                        .HasColumnType("int");

                    b.Property<Guid>("DistributorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DistributorId")
                        .IsUnique();

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Domain.DistributorManagement.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContactInfo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ContactType")
                        .HasColumnType("int");

                    b.Property<Guid>("DistributorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DistributorId")
                        .IsUnique();

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("Domain.DistributorManagement.Distributor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid?>("RecomendatorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RecomendatorId");

                    b.ToTable("Distributors");
                });

            modelBuilder.Entity("Domain.DistributorManagement.IdCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DistributorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DocNum")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("DocSeries")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCardType")
                        .HasColumnType("int");

                    b.Property<string>("IdNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("IssuingAgency")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DistributorId")
                        .IsUnique();

                    b.HasIndex("IdNumber")
                        .IsUnique();

                    b.ToTable("IdCard");
                });

            modelBuilder.Entity("Domain.ProductManagement.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Domain.SaleManagement.Sale", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("DistributorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DistributorId");

                    b.HasIndex("ProductId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("Domain.BonusManagement.Bonus", b =>
                {
                    b.HasOne("Domain.DistributorManagement.Distributor", "Distributor")
                        .WithMany()
                        .HasForeignKey("DistributorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.DistributorManagement.Distributor", null)
                        .WithMany("Bonuses")
                        .HasForeignKey("DistributorId1");

                    b.Navigation("Distributor");
                });

            modelBuilder.Entity("Domain.DistributorManagement.Address", b =>
                {
                    b.HasOne("Domain.DistributorManagement.Distributor", "Distributor")
                        .WithOne("Address")
                        .HasForeignKey("Domain.DistributorManagement.Address", "DistributorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Distributor");
                });

            modelBuilder.Entity("Domain.DistributorManagement.Contact", b =>
                {
                    b.HasOne("Domain.DistributorManagement.Distributor", "Distributor")
                        .WithOne("Contact")
                        .HasForeignKey("Domain.DistributorManagement.Contact", "DistributorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Distributor");
                });

            modelBuilder.Entity("Domain.DistributorManagement.Distributor", b =>
                {
                    b.HasOne("Domain.DistributorManagement.Distributor", "Recomendator")
                        .WithMany()
                        .HasForeignKey("RecomendatorId");

                    b.Navigation("Recomendator");
                });

            modelBuilder.Entity("Domain.DistributorManagement.IdCard", b =>
                {
                    b.HasOne("Domain.DistributorManagement.Distributor", "Distributor")
                        .WithOne("IdCardInfo")
                        .HasForeignKey("Domain.DistributorManagement.IdCard", "DistributorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Distributor");
                });

            modelBuilder.Entity("Domain.SaleManagement.Sale", b =>
                {
                    b.HasOne("Domain.DistributorManagement.Distributor", "Distributor")
                        .WithMany("Sales")
                        .HasForeignKey("DistributorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.ProductManagement.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Distributor");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.DistributorManagement.Distributor", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Bonuses");

                    b.Navigation("Contact")
                        .IsRequired();

                    b.Navigation("IdCardInfo")
                        .IsRequired();

                    b.Navigation("Sales");
                });
#pragma warning restore 612, 618
        }
    }
}
