using Domain.DistributorManagement;

namespace Application.DistributorManagement.Dtos
{
    public class DistributorDtoModel : DistributorBaseDtoModel
    {
        public IdCardDtoModel? IdCardInfo { get; private set; }
        public ContactDtoModel? Contact { get; private set; }
        public AddressDtoModel? Address { get; private set; }

        public static DistributorDtoModel MapToDto(Distributor distributor, bool includeNavProperties = true)
        {
            var model = new DistributorDtoModel
            {
                Id = distributor.Id,
                FirstName = distributor.FirstName,
                LastName = distributor.LastName,
                BirthDate = distributor.BirthDate,
                Gender = distributor.Gender,
                Picture = distributor.Picture,
            };

            if (includeNavProperties)
            {
                model.IdCardInfo = new IdCardDtoModel(distributor.IdCardInfo);
                model.Contact = new ContactDtoModel(distributor.Contact);
                model.Address = new AddressDtoModel(distributor.Address);
            }

            return model;
        }
    }
}
