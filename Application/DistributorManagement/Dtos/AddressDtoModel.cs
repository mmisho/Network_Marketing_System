using Domain.DistributorManagement;
using Domain.DistributorManagement.Enum;

namespace Application.DistributorManagement.Dtos
{
    public class AddressDtoModel
    {
        public AddressDtoModel(Address address)
        {
            AddressType = address.AddressType;
            AddressInfo = address.AddressInfo;
        }
        public AddressTypeEnum AddressType { get; set; }
        public string AddressInfo { get; set; }
    }
}
