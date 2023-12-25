using Domain.ProductManagement.Repository;
using Domain.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ProductManagement.Commands.Delete.DeleteByCode
{
    public class DeleteProductByCodeCommandHandler : IRequestHandler<DeleteProductByCodeCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductByCodeCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteProductByCodeCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Query(x => x.Code == request.Code).FirstOrDefaultAsync();

            if (product == null)
            {
                throw new KeyNotFoundException($"Product was not found with Code: {request.Code}");
            }

            _productRepository.Delete(product);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
