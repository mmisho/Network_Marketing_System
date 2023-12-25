using Application.DistributorManagement.Dtos;
using Domain.DistributorManagement.Repository;
using MediatR;

namespace Application.DistributorManagement.Queries.GetDistributor
{
    public class GetDistributorQueryHandler : IRequestHandler<GetDistributorQueryRequest, GetDistributorQueryResponse>
    {
        private readonly IDistributorRepository _distributorRepository;

        public GetDistributorQueryHandler(IDistributorRepository distributorRepository)
        {
            _distributorRepository = distributorRepository;
        }

        public async Task<GetDistributorQueryResponse> Handle(GetDistributorQueryRequest request, CancellationToken cancellationToken)
        {
            var distributor = await _distributorRepository.OfIdAsync(request.Id);

            if (distributor == null)
            {
                throw new KeyNotFoundException($"Distributor was not found for Id: {request.Id}");
            }

            var response = new GetDistributorQueryResponse
            {
                Distributor = DistributorDtoModel.MapToDto(distributor)
            };

            return response;
        }
    }
}
