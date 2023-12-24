using Domain.DistributorManagement.Repository;
using Domain.Shared;
using MediatR;

namespace Application.DistributorManagement.Commands.Delete
{
    public class DeleteDistributorCommandHandler : IRequestHandler<DeleteDistributorCommand>
    {
        private readonly IDistributorRepository _distributorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDistributorCommandHandler(IDistributorRepository distributorRepository, IUnitOfWork unitOfWork)
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

            _distributorRepository.Delete(distributor);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
