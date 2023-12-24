using Domain.SaleManagement;
using Domain.SaleManagement.Repository;
using Infrastructure.DataAccess;

namespace Infrastructure.Repositories.SaleManagement
{
    public class SaleRepository(EFDbContext dbContext) : EFBaseRepository<EFDbContext, Sale>(dbContext), ISaleRepository
    {
    }
}
