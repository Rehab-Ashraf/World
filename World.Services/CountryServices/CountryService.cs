
namespace World.Services.CountryServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using World.Core.DomainEntities.Countries;
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
    }
}
