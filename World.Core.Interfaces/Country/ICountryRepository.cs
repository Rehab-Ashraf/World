
namespace World.Core.Interfaces.Country
{
    using World.Core.DomainEntities.Countries;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public interface ICountryRepository
    {
        Task<int> AddCountryAsync(Country country);
        Task<List<Country>> GetCountriesAsync();
    }
}
