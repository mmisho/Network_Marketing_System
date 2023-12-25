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
            ValidateContact(contactInfo);

            ContactType = contactType;
            ContactInfo = contactInfo;
        }

        public void ChangeDetails(ContactTypeEnum contactType, string contactInfo)
        {
            ValidateContact(contactInfo);

            ContactType = contactType;
            ContactInfo = contactInfo;
        }

        public override Guid Id { get; set; }
        public ContactTypeEnum ContactType { get; private set; }
        public string ContactInfo { get; private set; }
        public virtual Distributor? Distributor { get; private set; }
        public Guid DistributorId { get; private set; }

        private void ValidateContact(string contactInfo)
        {
            if (string.IsNullOrEmpty(contactInfo))
            {
                throw new ArgumentNullException($"{nameof(contactInfo)} cannot be null or empty");
            }

            if (contactInfo.Length > 100)
            {
                throw new ArgumentOutOfRangeException($"{nameof(contactInfo)} lenth should not be greater than 100");
            }
        }
    }
}
