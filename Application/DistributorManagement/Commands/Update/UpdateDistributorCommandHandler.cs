using Domain.DistributorManagement;
using Domain.DistributorManagement.Repository;
using Domain.Shared;
using MediatR;

namespace Application.DistributorManagement.Commands.Update
{
    public class UpdateDistributorCommandHandler : IRequestHandler<UpdateDistributorCommand>
    {
        private readonly IDistributorRepository _distributorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDistributorCommandHandler(IDistributorRepository distributorRepository, IUnitOfWork unitOfWork)
        {
            _distributorRepository = distributorRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(UpdateDistributorCommand request, CancellationToken cancellationToken)
        {
            var distributor = await _distributorRepository.OfIdAsync(request.Id);

            if (distributor == null)
            {
                throw new KeyNotFoundException($"Distributor was not found for Id: {request.Id}");
            }

            if (request.RecomendatorId != null)
            {
                var recomendator = await _distributorRepository.OfIdAsync(request.Id);

                if (recomendator == null)
                {
                    throw new KeyNotFoundException($"Recomendator was not found for Id: {request.RecomendatorId}");
                }
            }

            var idCard = new IdCard();
            idCard.Create(request.IdCard.IdCardType, request.IdCard.DocSeries, request.IdCard.DocNum, request.IdCard.ReleaseDate,
                                              request.IdCard.ExpirationDate, request.IdCard.IdNumber, request.IdCard.IssuingAgency);

            var contact = new Contact();
            contact.Create(request.Contact.ContactType, request.Contact.ContactInfo);

            var address = new Address();
            address.Create(request.Address.AddressType, request.Address.AddressInfo);

            distributor.ChangeDetails(request.FirstName, request.LastName, request.BirthDate, request.Gender, request.Picture,
                                      idCard, contact, address, request.RecomendatorId);

            _distributorRepository.Update(distributor);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
