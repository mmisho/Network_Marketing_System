using Domain.DistributorManagement;
using Domain.DistributorManagement.Repository;
using Domain.Shared;
using MediatR;

namespace Application.DistributorManagement.Commands.Create
{
    public class CreateDistributorCommandHandler : IRequestHandler<CreateDistributorCommand>
    {
        private readonly IDistributorRepository _distributorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDistributorCommandHandler(
            IDistributorRepository distributorRepository,
            IUnitOfWork unitOfWork)
        {
            _distributorRepository = distributorRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(CreateDistributorCommand request, CancellationToken cancellationToken)
        {
            if (request.RecomendatorId != null)
            {
                await ValidateRecomendator(request.RecomendatorId.Value);
            }
            var idCard = new IdCard();
            idCard.Create(request.IdCard.IdCardType, request.IdCard.DocSeries, request.IdCard.DocNum, request.IdCard.ReleaseDate, request.IdCard.ExpirationDate, request.IdCard.IdNumber, request.IdCard.IssuingAgency);

            var contact = new Contact();
            contact.Create(request.Contact.ContactType, request.Contact.ContactInfo);

            var address = new Address();
            address.Create(request.Address.AddressType, request.Address.AddressInfo);

            if (request.RecomendatorId != null)
            {
                var recomendator = _distributorRepository.OfIdAsync(request.RecomendatorId.Value);

                if (recomendator == null)
                {
                    throw new KeyNotFoundException($"Recomendator was not found for Id :{request.RecomendatorId}");
                }
            }

            var distributor = new Distributor();
            distributor.Create(request.FirstName, request.LastName, request.BirthDate, request.Gender, string.Empty, idCard, contact, address, request.RecomendatorId);

            await _distributorRepository.InsertAsync(distributor);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }

        private async Task ValidateRecomendator(Guid recomendatorId)
        {
            var recomendationCount = _distributorRepository.Query(x => x.RecomendatorId == recomendatorId).Count();

            if (recomendationCount > 2)
            {
                throw new InvalidOperationException($"Distributor with Id:{recomendatorId} has already used all his/her recomendations");
            }

            var secondLevel = await _distributorRepository.OfIdAsync(recomendatorId);
            var sixthLevel = secondLevel?.Recomendator?.Recomendator?.Recomendator?.Recomendator;

            if (sixthLevel != null)
            {
                throw new InvalidOperationException($"There is allowed 5 level hierarchy of recomendations");
            }
        }
    }
}
