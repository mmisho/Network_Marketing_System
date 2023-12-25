using Domain.DistributorManagement.Repository;
using Domain.ProductManagement.Repository;
using Domain.SaleManagement;
using Domain.SaleManagement.Repository;
using Domain.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.SaleManagement.Commands.CreateSale
{
    public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IDistributorRepository _distributorRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitofWork;

        public CreateSaleCommandHandler(
            ISaleRepository saleRepository,
            IDistributorRepository distributorRepository,
            IProductRepository productRepository,
            IUnitOfWork unitofWork)
        {
            _saleRepository = saleRepository;
            _distributorRepository = distributorRepository;
            _productRepository = productRepository;
            _unitofWork = unitofWork;
        }

        public async Task<Unit> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var distrubutor = await _distributorRepository.OfIdAsync(request.DistributorId);

            if (distrubutor == null)
            {
                throw new KeyNotFoundException($"Distributor was not found for Id: {request.DistributorId}");
            }

            var product = await _productRepository.Query(x => x.Code == request.ProductCode).FirstOrDefaultAsync();

            if (product == null)
            {
                throw new KeyNotFoundException($"Product was not found with Code: {request.ProductCode}");
            }

            var sale = new Sale();
            sale.Create(distrubutor, request.SaleDate, product, request.Cost, request.UnitPrice, request.Price);

            await _saleRepository.InsertAsync(sale);
            await _unitofWork.SaveAsync();

            return Unit.Value;
        }
    }
}
