
namespace World.Api.Models.City
{
    using System.Collections.Generic;
    using World.Core.DomainEntities.Paging;
    using World.Core.DomainEntities.Cities;
    public class GetCitiesOutPutModel
    {
        public int PageNumber { get; private set; }
        public int PageCount { get; private set; }
        public int PageSize { get; private set; }
        public int RowCount { get; private set; }
        public List<CityModel> Result { get; set; }

        public static GetCitiesOutPutModel Create(List<CityModel> cities , PaginationResult<City> paginationResult)
        {
            return new GetCitiesOutPutModel
            {
                PageNumber = paginationResult.PageNumber,
                PageSize = paginationResult.PageSize,
                PageCount = paginationResult.PageCount,
                RowCount = paginationResult.RowCount,
                Result = cities
            };
        }


    }
}
