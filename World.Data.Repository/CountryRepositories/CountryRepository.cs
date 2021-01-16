

namespace World.Data.Repository.CountryRepositories
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using World.Core.DomainEntities.Countries;
    using World.Core.Interfaces.Country;
    using World.Data.EF.Context;
    public class CountryRepository:ICountryRepository
    {
        private readonly WorldDbContext _contect;

        public CountryRepository( WorldDbContext context)
        {
            _contect = context;
        }

        public async Task<int> AddCountryAsync(Country country)
        {
            await _contect.AddAsync(country);
            await _contect.SaveChangesAsync();
            return country.Id;
        }

        public async Task<List<Country>> GetCountriesAsync()
        {
            return await _contect.Countries.ToListAsync();
        }
    }
}
