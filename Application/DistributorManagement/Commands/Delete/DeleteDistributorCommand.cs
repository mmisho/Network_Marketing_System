using MediatR;

namespace Application.DistributorManagement.Commands.Delete
{
    public record DeleteDistributorCommand(Guid DistributorId) : IRequest;
}
