
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using World.Core.DomainEntities.Paging;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq.Dynamic.Core;



namespace World.Data.Repository.PagingRepository
{
    internal static class LinqExtension
    {

        internal static async Task<PaginationResult<TEntity>> GetPagedResultAsync<TEntity>(
            this IQueryable<TEntity> query, int page, int pageSize, 
            string sortColumn ,string sortOrder,
            string filterColumn,string filterQuery) where TEntity : class
        {
            if (!String.IsNullOrEmpty(filterColumn) && !String.IsNullOrEmpty(filterQuery))
            {
                string saerch = String.Format("{0}.Contains({1})", filterColumn, filterQuery);
                query = query.Where(String.Format("{0}.Contains(@0)", filterColumn), filterQuery);

            }
            if (!String.IsNullOrEmpty(sortColumn))
            {
                sortOrder = !String.IsNullOrEmpty(sortOrder)
                && sortOrder.ToUpper() == "ASC"? "ASC": "DESC";
                query = query.OrderBy(
                String.Format("{0} {1}", sortColumn, sortOrder));
            }

            var paginationResult = PaginationResult<TEntity>.New()
            .Update(page, pageSize, query.Count());

            var pageCount = (double)paginationResult.RowCount / pageSize;
            paginationResult.UpdatePageCount((int)Math.Ceiling(pageCount));

            var skip = (page - 1) * pageSize;
            var result = await query.Skip(skip).Take(pageSize).ToListAsync();
            paginationResult.UpdateResult(result);

            return paginationResult;
        }
    }


}
