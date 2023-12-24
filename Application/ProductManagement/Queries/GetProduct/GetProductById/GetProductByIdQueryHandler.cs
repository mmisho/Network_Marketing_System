using Application.ProductManagement.Dtos;
using Domain.ProductManagement.Repository;
using MediatR;

namespace Application.ProductManagement.Queries.GetProduct.GetProductByCode
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, GetProductByIdQueryResponse>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.OfIdAsync(request.Id);

            if (product == null)
            {
                throw new KeyNotFoundException($"Product was not found for Id: {request.Id}");
            }

            var respone = new GetProductByIdQueryResponse()
            {
                Product = new ProductDtoModel(product.Id, product.Code, product.Name, product.UnitPrice)
            };

            return respone; 
        }
    }
}
