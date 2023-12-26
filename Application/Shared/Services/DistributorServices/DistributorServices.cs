using Domain.DistributorManagement.Repository;

namespace Application.Shared.Services.DistributorServices
{
    public class DistributorServices : IDistributorService
    {
        private readonly IDistributorRepository _distributorRepository;

        public DistributorServices(IDistributorRepository distributorRepository)
        {
            _distributorRepository = distributorRepository;
        }

        public async Task ValidateRecomendatorAsync(Guid recomendatorId)
        {
            var recomendator = await _distributorRepository.OfIdAsync(recomendatorId);

            if (recomendator == null)
            {
                throw new KeyNotFoundException($"Recomendator was not found for Id: {recomendatorId}");
            }

            var recomendationCount = _distributorRepository.Query(x => x.RecomendatorId == recomendatorId).Count();

            if (recomendationCount > 2)
            {
                throw new InvalidOperationException($"Distributor with Id: {recomendatorId} has already used all his/her recomendations");
            }

            var sixthLevel = recomendator?.Recomendator?.Recomendator?.Recomendator?.Recomendator;

            if (sixthLevel != null)
            {
                throw new InvalidOperationException($"There is allowed maximum 5 level hierarchy of recomendations");
            }
        }
    }
}
