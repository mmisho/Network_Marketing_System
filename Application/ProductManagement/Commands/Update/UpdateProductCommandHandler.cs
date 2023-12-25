using Application.Shared.Services.ProductServices;
using Domain.ProductManagement.Repository;
using Domain.Shared;
using MediatR;
namespace Application.ProductManagement.Commands.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _productService;

        public UpdateProductCommandHandler(
            IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            IProductService productService)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _productService = productService;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.OfIdAsync(request.Id);

            if (product == null)
            {
                throw new KeyNotFoundException($"Product was not found for Id: {request.Id}");
            }

            await _productService.ProductCodeValidation(request.Code);

            product.ChangeDetails(request.Code, request.Name, request.UnitPrice);

            _productRepository.Update(product);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
