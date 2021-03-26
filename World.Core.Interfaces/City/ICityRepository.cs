

namespace World.Core.Interfaces.City
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using World.Core.DomainEntities.Cities;
    using World.Core.DomainEntities.Paging;

    public interface ICityRepository
    {
        Task<int> AddCityAsync(City city);
        Task<PaginationResult<City>> GetAllCitiesAsync(PagingParams pagingParams,
                                                       string sortColumn, 
                                                       string sortOrder,
                                                       string filterColumn,
                                                       string filterQuery);
        Task<bool> IsDupeCityAsync(City city);
    }
}
