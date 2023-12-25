using Domain.DistributorManagement.Enum;
using Domain.Shared;

namespace Domain.DistributorManagement
{
    public class Address : BaseEntity<Guid>
    {
        public Address()
        {
            AddressInfo = string.Empty;
        }

        public void Create(AddressTypeEnum addressType, string addressInfo)
        {
            ValidateAddress(addressInfo);

            AddressType = addressType;
            AddressInfo = addressInfo;
        }

        public void ChangeDetails(AddressTypeEnum addressType, string addressInfo)
        {
            ValidateAddress(addressInfo);

            AddressType = addressType;
            AddressInfo = addressInfo;
        }

        public override Guid Id { get; set; }
        public AddressTypeEnum AddressType { get; private set; }
        public string AddressInfo { get; private set; }
        public virtual Distributor? Distributor { get; private set; }
        public Guid DistributorId { get; private set; }

        private void ValidateAddress(string addressInfo)
        {
            if (string.IsNullOrEmpty(addressInfo))
            {
                throw new ArgumentNullException($"{nameof(addressInfo)} cannot be null or empty");
            }

            if (addressInfo.Length > 100)
            {
                throw new ArgumentOutOfRangeException($"{nameof(addressInfo)} length should not be greater than 100");
            }
        }
    }
}
