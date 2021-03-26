using System;
using System.Collections.Generic;

namespace World.Core.DomainEntities.Paging
{
    public class PaginationResult<TEntity>
    {
        public int PageNumber { get; private set; }
        public int PageCount { get; private set; }
        public int PageSize { get; private set; }
        public int RowCount { get; private set; }
        public List<TEntity> Result { get; private set; }

        public static PaginationResult<TEntity> New()
        {
            return new PaginationResult<TEntity>();
        }

        public PaginationResult<TEntity> Update(int page, int pageSize, int rowCount)
        {
            PageNumber = page;
            PageSize = pageSize;
            RowCount = rowCount;
            return this;
        }

        public PaginationResult<TEntity> UpdatePageCount(int pageCount)
        {
            PageCount = pageCount;
            return this;
        }

        public PaginationResult<TEntity> UpdateResult(List<TEntity> result)
        {
            Result = result;
            return this;
        }
    }
}