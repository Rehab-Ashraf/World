
namespace World.Services.CountryServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using World.Core.DomainEntities.Countries;
    using World.Core.DomainEntities.Paging;
    using World.Core.Interfaces.Country;
    public class CountryService:ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public async Task<int> AddCountryAsync(Country country)
        {
            return await _countryRepository.AddCountryAsync(country);
        }

        public async Task<List<Country>> GetCountriesAsync()
        {
            return await _countryRepository.GetCountriesAsync();
        }
        public async Task<PaginationResult<Country>> GetCountriesAsync(PagingParams pagingParams,string sortColumn ,string sortOrder , string filterColumn , string filterQuery)
        {
            return await _countryRepository.GetCountriesAsync(pagingParams ,  sortColumn ,sortOrder , filterColumn , filterQuery);
        }
    }
}
