using API.DTOs;
using System.Linq.Expressions;

namespace API.Extensions
{
    public static class QueryExtension
    {
        public static IQueryable<T>ApplySorting<T>(this IQueryable<T> query, UnitQueryDto unitQuery, Dictionary<string, Expression<Func<T, object>>> sortCol)
        {
            if (string.IsNullOrEmpty(unitQuery.SortBy) || !sortCol.ContainsKey(unitQuery.SortBy))
            {
                return query;
            }

            bool isSortAscending = unitQuery.IsSortAscending ?? false;

            if (isSortAscending)
            {
                query = query.OrderBy(sortCol[unitQuery.SortBy]);
            }
            else
            {
                query = query.OrderByDescending(sortCol[unitQuery.SortBy]);
            }

            return query;
        }



        //paginacija
        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, UnitQueryDto unitQuery)
        {
            int page = unitQuery.Page ?? 1;
            int pageSize = unitQuery.PageSize ?? 5;

            if (page <= 0)
            {
                page = 1;
            }
            if (pageSize <= 0)
            {
                pageSize = 5;
            }

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
    

