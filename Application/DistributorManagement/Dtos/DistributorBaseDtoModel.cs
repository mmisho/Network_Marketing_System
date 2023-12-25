using Domain.DistributorManagement;
using Domain.DistributorManagement.Enum;

namespace Application.DistributorManagement.Dtos
{
    public class DistributorBaseDtoModel
    {
        public Guid Id { get; protected set; }
        public string FirstName { get; protected set; } = string.Empty;
        public string LastName { get; protected set; } = string.Empty;
        public DateTime BirthDate { get; protected set; }
        public GenderEnum Gender { get; protected set; }
        public byte[]? Picture { get; protected set; }

        public static DistributorBaseDtoModel MapToDto(Distributor distributor)
        {
            return DistributorDtoModel.MapToDto(distributor, false);
        }

        public void SetPicture(byte[] picture)
        {
            Picture = picture;
        }
    }
}
