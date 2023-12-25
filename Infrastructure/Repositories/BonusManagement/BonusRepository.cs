using Domain.BonusManagement;
using Domain.BonusManagement.Repository;
using Infrastructure.DataAccess;

namespace Infrastructure.Repositories.BonusManagement
{
    public class BonusRepository(EFDbContext dbContext) : EFBaseRepository<EFDbContext, Bonus>(dbContext), IBonusRepository
    {
    }
}
