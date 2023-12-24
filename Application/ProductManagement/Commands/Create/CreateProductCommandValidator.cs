using FluentValidation;

namespace Application.ProductManagement.Commands.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Code).NotEmpty().NotNull();
            RuleFor(x => x.Name).NotEmpty().NotNull();
        }
    }
}
