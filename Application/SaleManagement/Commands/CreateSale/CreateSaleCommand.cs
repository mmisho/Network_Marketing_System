using MediatR;

namespace Application.SaleManagement.Commands.CreateSale
{
    public record CreateSaleCommand(Guid DistributorId, DateTime SaleDate, string ProductCode, int cost, decimal UnitPrice, decimal Price) : IRequest;
}
