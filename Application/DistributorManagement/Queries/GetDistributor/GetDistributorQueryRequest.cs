using MediatR;

namespace Application.DistributorManagement.Queries.GetDistributor
{
    public class GetDistributorQueryRequest : IRequest<GetDistributorQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
