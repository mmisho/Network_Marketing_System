using MediatR;

namespace Application.ProductManagement.Commands.Delete.DeleteById
{
    public record DeleteProductByIdCommand(Guid Id) : IRequest;
}
