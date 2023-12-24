using Application.SaleManagement.Dtos;

namespace Application.SaleManagement.Queries.GetSales
{
    public class GetSalesQueryResponse
    {
        public IEnumerable<SaleDtoModel>? Sales { get; set; }
    }
}
