using MediatR;

namespace Application.ProductManagement.Commands.Update
{
    public class UpdateProductCommand : IRequest
    {
        public Guid Id { get; private set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
