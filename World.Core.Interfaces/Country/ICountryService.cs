
namespace World.Core.Interfaces.Country
{
    using World.Core.DomainEntities.Countries;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using World.Core.DomainEntities.Paging;

    public interface ICountryService
    {
        Task<int> AddCountryAsync(Country country);
        Task<List<Country>> GetCountriesAsync();
        Task<PaginationResult<Country>> GetCountriesAsync(PagingParams pagingParams,
                                                          string sortColumn ,
                                                          string sortOrder,
                                                          string filterColumn,
                                                          string filterQuery);
    }
}
