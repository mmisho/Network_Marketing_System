using Application.DistributorManagement.Dtos;
using Domain.DistributorManagement.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.DistributorManagement.Queries.GetDistributors
{
    public class GetDistributorsQueryHandler : IRequestHandler<GetDistributorsQueryRequest, GetDistributorsQueryResponse>
    {
        private readonly IDistributorRepository _distributorRepository;

        public GetDistributorsQueryHandler(IDistributorRepository distributorRepository)
        {
            _distributorRepository = distributorRepository;
        }
        public async Task<GetDistributorsQueryResponse> Handle(GetDistributorsQueryRequest request, CancellationToken cancellationToken)
        {
            var distributors = await _distributorRepository.Query().ToListAsync();

            var response = new GetDistributorsQueryResponse
            {
                Distributors = distributors.Select(x => DistributorDtoModel.MapToDto(x))
            };

            return response;
        }
    }
}
