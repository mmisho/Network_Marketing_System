using Domain.DistributorManagement.Enum;

namespace Application.DistributorManagement.Models
{
    public class AddressModel
    {
        public AddressTypeEnum AddressType { get; set; }
        public string AddressInfo { get; set; } = string.Empty;
    }
}
