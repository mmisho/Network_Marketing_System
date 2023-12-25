using Domain.DistributorManagement;
using Domain.ProductManagement;
using Domain.Shared;

namespace Domain.SaleManagement
{
    public class Sale : BaseEntity<Guid>
    {
        public Sale()
        {
            Distributor = new Distributor();
            Product = new Product();
        }

        public void Create(Distributor distributor, DateTime saleDate, Product product, decimal cost, decimal unitPrice, decimal price)
        {
            if (distributor is null)
            {
                throw new ArgumentNullException($"{nameof(distributor)} cannot be null");
            }

            if (product is null)
            {
                throw new ArgumentNullException($"{nameof(product)} cannot be null");
            }

            Distributor = distributor;
            SaleDate = saleDate;
            Product = product;
            Cost = cost;
            UnitPrice = unitPrice;
            Price = price;
        }

        public override Guid Id { get; set; }
        public virtual Distributor Distributor { get; private set; }
        public Guid DistributorId { get; private set; }
        public DateTime SaleDate { get; private set; }
        public virtual Product Product { get; private set; }
        public Guid ProductId { get; private set; }
        public decimal Cost { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Price { get; private set; }
    }
}
