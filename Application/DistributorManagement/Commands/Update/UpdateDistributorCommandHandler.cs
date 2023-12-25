using Application.Shared.Services.DistributorServices;
using Domain.DistributorManagement.Repository;
using Domain.Shared;
using MediatR;

namespace Application.DistributorManagement.Commands.Update
{
    public class UpdateDistributorCommandHandler : IRequestHandler<UpdateDistributorCommand>
    {
        private readonly IDistributorRepository _distributorRepository;
        private readonly IDistributorService _distributorService;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDistributorCommandHandler(
            IDistributorRepository distributorRepository,
            IDistributorService distributorService,
            IUnitOfWork unitOfWork)
        {
            _distributorRepository = distributorRepository;
            _distributorService = distributorService;
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
                var recomendator = await _distributorRepository.OfIdAsync(request.RecomendatorId.Value);

                if (recomendator == null)
                {
                    throw new KeyNotFoundException($"Recomendator was not found for Id: {request.RecomendatorId}");
                }

                await _distributorService.ValidateRecomendatorAsync(request.RecomendatorId.Value);
            }


            distributor.IdCardInfo.ChangeDetails(request.IdCard.IdCardType, request.IdCard.DocSeries, request.IdCard.DocNum, request.IdCard.ReleaseDate,
                                                 request.IdCard.ExpirationDate, request.IdCard.IdNumber, request.IdCard.IssuingAgency);

            distributor.Contact.ChangeDetails(request.Contact.ContactType, request.Contact.ContactInfo);

            distributor.Address.ChangeDetails(request.Address.AddressType, request.Address.AddressInfo);

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

            distributor.ChangeDetails(request.FirstName, request.LastName, request.BirthDate, request.Gender, picture,
                                      request.RecomendatorId);

            _distributorRepository.Update(distributor);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
