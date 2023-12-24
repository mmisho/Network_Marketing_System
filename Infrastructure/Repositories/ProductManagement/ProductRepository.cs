using Domain.ProductManagement;
using Domain.ProductManagement.Repository;
using Infrastructure.DataAccess;

namespace Infrastructure.Repositories.ProductManagement
{
    public class ProductRepository(EFDbContext dbContext) : EFBaseRepository<EFDbContext, Product>(dbContext), IProductRepository
    {
    }
}
