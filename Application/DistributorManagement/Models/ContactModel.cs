using Domain.DistributorManagement.Enum;

namespace Application.DistributorManagement.Models
{
    public class ContactModel
    {
        public ContactTypeEnum ContactType { get; set; }
        public string ContactInfo { get; set; } = string.Empty;
    }
}
