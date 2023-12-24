using Application.DistributorManagement.Models;
using Domain.DistributorManagement.Enum;
using MediatR;

namespace Application.DistributorManagement.Commands.Update
{
    public class UpdateDistributorCommand : IRequest
    {
        public Guid Id { get; private set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public GenderEnum Gender { get; set; }
        public string Picture { get; set; } = string.Empty;
        public IdCardModel IdCard { get; set; } = new();
        public ContactModel Contact { get; set; } = new();
        public AddressModel Address { get; set; } = new();
        public Guid? RecomendatorId  { get; set; }

        public void SetId(Guid Id)
        {
            this.Id = Id;
        }
    }
}
