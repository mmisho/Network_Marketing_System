using System.Linq.Expressions;

namespace Application.Shared.Extentions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TSource> Filter<TSource, TFilter>(this IQueryable<TSource> source, TFilter filter, Expression<Func<TSource, bool>> predicate)
        {
            if (predicate == null)
            {
                return source;
            }
            if (filter == null)
            {
                return source;
            }

            return source.Where(predicate); 
        }
    }
}
