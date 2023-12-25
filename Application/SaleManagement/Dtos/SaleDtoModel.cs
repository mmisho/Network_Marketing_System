using Application.DistributorManagement.Dtos;
using Application.ProductManagement.Dtos;
using Domain.SaleManagement;

namespace Application.SaleManagement.Dtos
{
    public class SaleDtoModel
    {
        public SaleDtoModel(Sale sale)
        {
            Distributor = DistributorBaseDtoModel.MapToDto(sale.Distributor);
            SaleDate = sale.SaleDate;
            Product = new(sale.Product.Id, sale.Product.Code, sale.Product.Name, sale.Product.UnitPrice);
            Cost = sale.Cost;
            Price = sale.Price;
        }

        public DistributorBaseDtoModel Distributor { get; private set; }
        public DateTime SaleDate { get; private set; }
        public ProductDtoModel Product { get; private set; }
        public decimal Cost { get; private set; }
        public decimal Price { get; private set; }
    }
}
