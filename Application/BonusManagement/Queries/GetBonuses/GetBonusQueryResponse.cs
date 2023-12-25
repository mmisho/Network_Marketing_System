using Application.BonusManagement.Dtos;

namespace Application.BonusManagement.Queries.GetBonuses
{
    public class GetBonusQueryResponse
    {
        public IEnumerable<BonusDtoModel>? Bonuses { get; set; }
    }
}
