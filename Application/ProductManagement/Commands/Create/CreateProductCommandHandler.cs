using Application.Shared.Services.ProductServices;
using Domain.ProductManagement;
using Domain.ProductManagement.Repository;
using Domain.Shared;
using MediatR;

namespace Application.ProductManagement.Commands.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _productService;

        public CreateProductCommandHandler(
            IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            IProductService productService)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _productService = productService;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await _productService.ProductCodeValidation(request.Code);

            var product = new Product();
            product.Create(request.Code, request.Name, request.UnitPrice);

            await _productRepository.InsertAsync(product);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
