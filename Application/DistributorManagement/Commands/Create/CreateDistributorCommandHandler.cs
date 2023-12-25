using Application.Shared.Services.DistributorServices;
using Domain.DistributorManagement;
using Domain.DistributorManagement.Repository;
using Domain.Shared;
using MediatR;

namespace Application.DistributorManagement.Commands.Create
{
    public class CreateDistributorCommandHandler : IRequestHandler<CreateDistributorCommand>
    {
        private readonly IDistributorRepository _distributorRepository;
        private readonly IDistributorService _distributorService;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDistributorCommandHandler(
            IDistributorRepository distributorRepository,
            IDistributorService distributorService,
            IUnitOfWork unitOfWork)
        {
            _distributorRepository = distributorRepository;
            _distributorService = distributorService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateDistributorCommand request, CancellationToken cancellationToken)
        {
            if (request.RecomendatorId != null)
            {
                await _distributorService.ValidateRecomendatorAsync(request.RecomendatorId.Value);
            }

            var idCard = new IdCard();
            idCard.Create(request.IdCard.IdCardType, request.IdCard.DocSeries, request.IdCard.DocNum, request.IdCard.ReleaseDate,
                          request.IdCard.ExpirationDate, request.IdCard.IdNumber, request.IdCard.IssuingAgency);

            var contact = new Contact();
            contact.Create(request.Contact.ContactType, request.Contact.ContactInfo);

            var address = new Address();
            address.Create(request.Address.AddressType, request.Address.AddressInfo);

            if (request.RecomendatorId != null)
            {
                var recomendator = _distributorRepository.OfIdAsync(request.RecomendatorId.Value);

                if (recomendator == null)
                {
                    throw new KeyNotFoundException($"Recomendator was not found for Id: {request.RecomendatorId}");
                }
            }

            byte[]? picture = null;

            if (request.Picture != null)
            {
                if (request.Picture.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        request.Picture.CopyTo(ms);
                        picture = ms.ToArray();
                    }
                }
            }

            var distributor = new Distributor();
            distributor.Create(request.FirstName, request.LastName, request.BirthDate, request.Gender, picture, idCard, contact, address, request.RecomendatorId);

            await _distributorRepository.InsertAsync(distributor);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
