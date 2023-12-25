using Application.BonusManagement.Dtos.Enums;
using MediatR;

namespace Application.BonusManagement.Queries.GetBonuses
{
    public class GetBonusQueryRequest : IRequest<GetBonusQueryResponse>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public BonusFilterEnum? BonusFilter { get; set; }
    }
}
