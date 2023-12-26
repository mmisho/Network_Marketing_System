using Domain.DistributorManagement.Repository;
using Domain.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.DistributorManagement.Commands.Delete
{
    public class DeleteDistributorCommandHandler : IRequestHandler<DeleteDistributorCommand>
    {
        private readonly IDistributorRepository _distributorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDistributorCommandHandler(
            IDistributorRepository distributorRepository,
            IUnitOfWork unitOfWork)
        {
            _distributorRepository = distributorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteDistributorCommand request, CancellationToken cancellationToken)
        {
            var distributor = await _distributorRepository.OfIdAsync(request.DistributorId);

            if (distributor == null)
            {
                throw new KeyNotFoundException($"Distributor was not found for Id: {request.DistributorId}");
            }

            var dependentDistributors = await _distributorRepository.Query(x => x.RecomendatorId == request.DistributorId).ToListAsync();

            if (dependentDistributors != null)
            {
                foreach (var d in dependentDistributors)
                {
                    d.ChangeDetails(d.FirstName, d.LastName, d.BirthDate, d.Gender, d.Picture, null);
                    _distributorRepository.Update(d);
                }
            }

            _distributorRepository.Delete(distributor);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
