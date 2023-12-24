using System.Linq.Expressions;

namespace Domain.Shared.Repository
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : class
    {
        Task<TAggregateRoot?> OfIdAsync(Guid id);
        void Delete(TAggregateRoot agregateRoot);
        Task InsertAsync(TAggregateRoot agregateRoot);
        void Update(TAggregateRoot agregateRoot);
        IQueryable<TAggregateRoot> Query(Expression<Func<TAggregateRoot, bool>>? expression = default);
    }
}
