using Domain.DistributorManagement;
using Domain.DistributorManagement.Repository;
using Infrastructure.DataAccess;

namespace Infrastructure.Repositories.DistributorManagement
{
    public class DistributorRepository(EFDbContext dbContext) : EFBaseRepository<EFDbContext, Distributor>(dbContext), IDistributorRepository
    {
    }
}
