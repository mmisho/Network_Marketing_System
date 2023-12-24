using Application.ProductManagement.Dtos;
using Domain.ProductManagement;
using Domain.ProductManagement.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ProductManagement.Queries.GetProduct.GetProductByCode
{
    public class GetProductByCodeQueryHandler : IRequestHandler<GetProductByCodeQueryRequest, GetProductByCodeQueryResponse>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByCodeQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<GetProductByCodeQueryResponse> Handle(GetProductByCodeQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Query(x => x.Code == request.Code).FirstOrDefaultAsync();

            if ( product == null )
            {
                throw new KeyNotFoundException($"Product was not found with Code {request.Code}");
            }

            var respone = new GetProductByCodeQueryResponse
            {
                Products = new ProductDtoModel(product.Id, product.Code, product.Name, product.UnitPrice)
            };

            return respone;
        }
    }
}
