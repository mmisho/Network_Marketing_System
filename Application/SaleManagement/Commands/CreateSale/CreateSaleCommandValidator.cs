using FluentValidation;

namespace Application.SaleManagement.Commands.CreateSale
{
    public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
    {
        public CreateSaleCommandValidator()
        {
        }
    }
}
