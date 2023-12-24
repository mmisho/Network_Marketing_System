using Domain.DistributorManagement.Enum;
using Domain.Shared;

namespace Domain.DistributorManagement
{
    public class Contact : BaseEntity<Guid>
    {
        public Contact()
        {
            ContactInfo = string.Empty;
        }

        public void Create(ContactTypeEnum contactType, string contactInfo)
        {
            if (string.IsNullOrEmpty(contactInfo))
            {
                throw new ArgumentNullException($"{nameof(contactInfo)} cannot be null or empty");
            }

            if (contactInfo.Length > 100)
            {
                throw new ArgumentOutOfRangeException($"{nameof(contactInfo)} lenth should not be greater than 100");
            }

            ContactType = contactType;
            ContactInfo = contactInfo;
        }

        public override Guid Id { get; set; }
        public ContactTypeEnum ContactType { get; private set; }
        public string ContactInfo { get; private set; }
    }
}
