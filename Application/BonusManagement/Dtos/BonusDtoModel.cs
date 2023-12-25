using Application.DistributorManagement.Dtos;
using Domain.BonusManagement;

namespace Application.BonusManagement.Dtos
{
    public class BonusDtoModel
    {
        public BonusDtoModel(Bonus bonus)
        {
            Id = bonus.Id;
            StartDate = bonus.StartDate;
            EndDate = bonus.EndDate;
            BonusAmount = bonus.BonusAmount;
            Distributor = DistributorBaseDtoModel.MapToDto(bonus.Distributor);
        }

        public Guid Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal BonusAmount { get; set; }
        public DistributorBaseDtoModel Distributor { get; set; }
    }
}
