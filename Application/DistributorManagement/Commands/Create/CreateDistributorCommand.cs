using Application.DistributorManagement.Models;
using Domain.DistributorManagement.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.DistributorManagement.Commands.Create
{
    public class CreateDistributorCommand() : IRequest
    {
        public string FirstName { get; set; } =  string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; } 
        public GenderEnum Gender { get; set; } 
        public IFormFile? Picture { get;  set; } 
        public IdCardModel IdCard { get; set; } = new();
        public ContactModel Contact { get; set; } = new();
        public AddressModel Address { get; set; } = new();
        public Guid? RecomendatorId { get; set; }
    }
}
