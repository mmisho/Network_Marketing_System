using Application.BonusManagement.Dtos;
using Application.Shared.Extentions;
using Domain.BonusManagement.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.BonusManagement.Queries.GetBonuses
{
    public class GetBonusQueryHandler : IRequestHandler<GetBonusQueryRequest, GetBonusQueryResponse>
    {
        private readonly IBonusRepository _bonusRepository;

        public GetBonusQueryHandler(IBonusRepository bonusRepository)
        {
            _bonusRepository = bonusRepository;
        }

        public async Task<GetBonusQueryResponse> Handle(GetBonusQueryRequest request, CancellationToken cancellationToken)
        {
            var bonuses = _bonusRepository.Query()
                                          .Filter(request.FirstName, x => x.Distributor.FirstName == request.FirstName)
                                          .Filter(request.LastName, x => x.Distributor.LastName == request.LastName);


            if (request.BonusFilter != null)
            {
                if (request.BonusFilter == Dtos.Enums.BonusFilterEnum.Max)
                {
                    bonuses.Filter(request.BonusFilter, x => x.BonusAmount == bonuses.Select(x => x.BonusAmount).Max());
                }
                else
                {
                    bonuses.Filter(request.BonusFilter, x => x.BonusAmount == bonuses.Select(x => x.BonusAmount).Min());
                }
            }

            var bonusList = await bonuses.ToListAsync();

            var response = new GetBonusQueryResponse
            {
                Bonuses = bonusList.Select(x => new BonusDtoModel(x))
            };

            return response;
        }
    }
}
