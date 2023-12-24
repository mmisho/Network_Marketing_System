using MediatR;

namespace Application.ProductManagement.Queries.GetProduct.GetProductByCode
{
    public class GetProductByCodeQueryRequest : IRequest<GetProductByCodeQueryResponse>
    {
        public string Code { get; set; } = string.Empty;
    }
}
