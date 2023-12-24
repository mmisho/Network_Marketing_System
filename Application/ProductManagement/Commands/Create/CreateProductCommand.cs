using MediatR;

namespace Application.ProductManagement.Commands.Create
{
    public record CreateProductCommand(string Code, string Name, decimal UnitPrice) : IRequest;
}
