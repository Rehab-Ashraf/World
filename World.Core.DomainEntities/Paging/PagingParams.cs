using System;
using System.Collections.Generic;
using System.Text;

namespace World.Core.DomainEntities.Paging
{
    public class PagingParams
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }
}
