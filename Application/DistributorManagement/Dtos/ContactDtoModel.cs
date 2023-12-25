using Domain.DistributorManagement;
using Domain.DistributorManagement.Enum;

namespace Application.DistributorManagement.Dtos
{
    public class ContactDtoModel
    {
        public ContactDtoModel(Contact contact)
        {
            ContactType = contact.ContactType;
            ContactInfo = contact.ContactInfo;
        }

        public ContactTypeEnum ContactType { get; set; }
        public string ContactInfo { get; set; } = string.Empty;
    }
}
