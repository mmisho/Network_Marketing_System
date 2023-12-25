using Domain.BonusManagement;
using Domain.BonusManagement.Repository;
using Domain.DistributorManagement;
using Domain.DistributorManagement.Repository;
using Domain.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.BonusManagement.Commands.Create
{
    public class CreateBonusCommandHandler : IRequestHandler<CreateBonusCommand>
    {
        private readonly IBonusRepository _bonusRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDistributorRepository _distributorRepository;

        public CreateBonusCommandHandler(
            IBonusRepository bonusRepository,
            IDistributorRepository distributorRepository,
            IUnitOfWork unitOfWork)
        {
            _bonusRepository = bonusRepository;
            _unitOfWork = unitOfWork;
            _distributorRepository = distributorRepository;
        }

        public async Task<Unit> Handle(CreateBonusCommand request, CancellationToken cancellationToken)
        {
            var distributors = await _distributorRepository.Query().ToListAsync();

            foreach (var distributor in distributors)
            {
                if (!distributor.Bonuses.Any())
                {
                    var bonus = new Bonus();
                    var bonusAmoount = await CalculateBonusAsync(distributor);

                    bonus.Create(null, DateTime.Now, bonusAmoount, distributor);

                    await _bonusRepository.InsertAsync(bonus);
                }
                else
                {
                    var bonus = new Bonus();
                    var startDate = distributor.Bonuses.Select(x => x.EndDate).Max();
                    var bonusAmount = await CalculateBonusAsync(distributor);

                    bonus.Create(startDate, DateTime.Now, bonusAmount, distributor);

                    distributor.Bonuses.Add(bonus);

                    await _bonusRepository.InsertAsync(bonus);
                }
            }

            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }

        private async Task<decimal> CalculateBonusAsync(Distributor distributor)
        {
            decimal bonus;

            bonus = (distributor.Sales.Where(x => x.SaleDate < DateTime.Now).Select(x => x.Price).Sum()) / 10;

            var firstLevelRecomendations = await _distributorRepository.Query(x => x.RecomendatorId == distributor.Id).ToListAsync();
            var firstBonus = firstLevelRecomendations.Select(x => x.Sales.Where(x => x.SaleDate < DateTime.Now).Select(x => x.Price).Sum()).Sum() * 5 / 100;

            var secondLevelRecomendations = await _distributorRepository.Query(x => firstLevelRecomendations.Select(x => x.RecomendatorId).Contains(x.Id)).ToListAsync();
            var secondBonus = secondLevelRecomendations.Select(x => x.Sales.Where(x => x.SaleDate < DateTime.Now).Select(x => x.Price).Sum()).Sum() / 100;

            return bonus + firstBonus + secondBonus;
        }
    }
}
