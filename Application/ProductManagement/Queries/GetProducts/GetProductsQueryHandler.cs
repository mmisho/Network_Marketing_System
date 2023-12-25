using Application.ProductManagement.Dtos;
using Domain.ProductManagement.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ProductManagement.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQueryRequest, GetProductsQueryResponse>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetProductsQueryResponse> Handle(GetProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.Query().ToListAsync();

            var response = new GetProductsQueryResponse()
            {
                Products = products.Select(x => new ProductDtoModel(x.Id, x.Code, x.Name, x.UnitPrice))
            };

            return response;
        }
    }
}
