using MediatR;

namespace Application.SaleManagement.Queries.GetSales
{
    public class GetSalesQueryRequest : IRequest<GetSalesQueryResponse>
    {
        public Guid? DistributorId { get; set; }
        public DateTime? SaleDate { get; set; }
        public string? ProductCode { get; set; }
    }
}
