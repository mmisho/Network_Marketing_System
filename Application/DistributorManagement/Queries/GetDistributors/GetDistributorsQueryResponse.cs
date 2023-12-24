using Application.DistributorManagement.Dtos;

namespace Application.DistributorManagement.Queries.GetDistributors
{
    public class GetDistributorsQueryResponse
    {
        public IEnumerable<DistributorDtoModel>? Distributors { get; set; }
    }
}
