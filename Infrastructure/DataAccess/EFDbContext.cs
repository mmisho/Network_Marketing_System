#nullable disable

using Domain.DistributorManagement;
using Domain.ProductManagement;
using Domain.SaleManagement;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.DataAccess
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Distributor> Distributors { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(EFDbContext)));
            base.OnModelCreating(modelBuilder);
        }
    }
}
