using System;

namespace World.Api.Models.Country
{
    using System.Collections.Generic;
    using World.Core.DomainEntities.Paging;
    using World.Core.DomainEntities.Countries;
    public class GetCountriesOutputModel
    {
        public int PageNumber { get; private set; }
        public int PageCount { get; private set; }
        public int PageSize { get; private set; }
        public int RowCount { get; private set; }
        public List<CountryModel>  Result { get; set; }
        public static GetCountriesOutputModel Create(List<CountryModel> countries , PaginationResult<Country> paginationResult)
        {
            return new GetCountriesOutputModel
            {
                PageNumber = paginationResult.PageNumber,
                PageSize = paginationResult.PageSize,
                PageCount = paginationResult.PageCount,
                RowCount = paginationResult.RowCount,
                Result = countries
            };
        }
    }
}
