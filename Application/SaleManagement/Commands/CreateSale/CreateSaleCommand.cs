using MediatR;

namespace Application.SaleManagement.Commands.CreateSale
{
    public record CreateSaleCommand(Guid DistributorId, DateTime SaleDate, string ProductCode, int Cost, decimal UnitPrice, decimal Price) : IRequest;
}
