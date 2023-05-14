using FilmReviewAPI.Extensions;
using System.Linq.Expressions;

namespace FilmReviewAPI.Extensions
{
    public static class IQueryableEx
    {
        public static IQueryable<T> Where<T>(this IQueryable<T> query, Expression<Func<T, bool>> expression, bool condition)
        {
            return condition ? query.Where(expression) : query;
        }
    }
}
