using Domain.DistributorManagement;
using Domain.Shared;

namespace Domain.BonusManagement
{
    public class Bonus : BaseEntity<Guid>
    {
        public Bonus()
        {
            Distributor = new();
        }

        public void Create(DateTime? startDate, DateTime endDate, decimal bonusAmount, Distributor distributor)
        {
            if (distributor is null)
            {
                throw new ArgumentNullException($"Distributor cannot be null");
            }

            StartDate = startDate;
            EndDate = endDate;
            BonusAmount = bonusAmount;
            Distributor = distributor;
        }

        public override Guid Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal BonusAmount { get; set; }
        public virtual Distributor Distributor { get; set; }
    }
}
