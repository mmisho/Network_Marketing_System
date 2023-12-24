using MediatR;

namespace Application.ProductManagement.Queries.GetProduct.GetProductByCode
{
    public class GetProductByIdQueryRequest : IRequest<GetProductByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
