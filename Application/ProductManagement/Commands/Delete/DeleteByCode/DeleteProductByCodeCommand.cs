using MediatR;

namespace Application.ProductManagement.Commands.Delete.DeleteByCode
{
    public record DeleteProductByCodeCommand(string Code) : IRequest;
}
