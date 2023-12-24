using Domain.SaleManagement.Repository;
using MediatR;
using Application.Shared.Extentions;
using Microsoft.EntityFrameworkCore;
using Application.SaleManagement.Dtos;

namespace Application.SaleManagement.Queries.GetSales
{
    public class GetSalesQueryHandler : IRequestHandler<GetSalesQueryRequest, GetSalesQueryResponse>
    {
        private readonly ISaleRepository _saleRepository;

        public GetSalesQueryHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<GetSalesQueryResponse> Handle(GetSalesQueryRequest request, CancellationToken cancellationToken)
        {
            var sales = await _saleRepository.Query()
                                             .Filter(request.DistributorId, x => x.DistributorId == request.DistributorId)
                                             .Filter(request.ProductCode, x => x.Product.Code == request.ProductCode)
                                             .Filter(request.SaleDate, x => x.SaleDate == request.SaleDate).ToListAsync();

            var response = new GetSalesQueryResponse
            {
                Sales = sales.Select(x => new SaleDtoModel(x))
            };

            return response;                           
        }
    }
}
