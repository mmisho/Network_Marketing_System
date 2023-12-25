using FluentValidation;

namespace Application.DistributorManagement.Commands.Create
{
    public class CreateDistributorCommandValidator : AbstractValidator<CreateDistributorCommand>
    {
        public CreateDistributorCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(x => x.BirthDate).NotEmpty().NotNull();
            RuleFor(x => x.Gender).NotEmpty().NotNull();
            RuleFor(x => x.IdCard).NotNull();
            RuleFor(x => x.IdCard.DocNum).MaximumLength(10);
            RuleFor(x => x.IdCard.DocSeries).MaximumLength(10);
            RuleFor(x => x.IdCard.IdNumber).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(x => x.IdCard.IssuingAgency).MaximumLength(100);
            RuleFor(x => x.Contact.ContactInfo).NotEmpty().NotNull().MaximumLength(100);
            RuleFor(x => x.Address.AddressInfo).NotEmpty().NotNull().MaximumLength(100);
        }
    }
}
