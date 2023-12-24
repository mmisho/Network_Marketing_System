using FluentValidation;

namespace Application.ProductManagement.Commands.Update
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Code).NotEmpty().NotNull();
            RuleFor(x => x.Name).NotEmpty().NotNull();
        }
    }
}
