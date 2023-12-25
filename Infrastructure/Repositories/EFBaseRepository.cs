using Domain.Shared.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class EFBaseRepository<TContext, TAggregateRoot> : IRepository<TAggregateRoot>
        where TAggregateRoot : class
        where TContext : DbContext
    {
        protected TContext _context;

        public EFBaseRepository(TContext context)
        {
            _context = context;
        }

        public void Delete(TAggregateRoot aggregateRoot)
        {
            _context.Remove(aggregateRoot);
        }

        public async Task InsertAsync(TAggregateRoot aggregateRoot)
        {
            await _context.Set<TAggregateRoot>().AddAsync(aggregateRoot);
        }

        public async Task<TAggregateRoot?> OfIdAsync(Guid id)
        {
            return await _context.Set<TAggregateRoot>().FindAsync(id);
        }

        public IQueryable<TAggregateRoot> Query(Expression<Func<TAggregateRoot, bool>>? expression = null)
        {
            return expression == null ? _context.Set<TAggregateRoot>().AsQueryable() : _context.Set<TAggregateRoot>().Where(expression);
        }

        public void Update(TAggregateRoot aggregateRoot)
        {
            _context.Entry(aggregateRoot).State = EntityState.Modified;
        }
    }
}
