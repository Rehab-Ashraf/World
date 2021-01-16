
namespace World.Data.Repository.CityRepositories
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using World.Core.DomainEntities.Cities;
    using World.Core.DomainEntities.Countries;
    using World.Core.Interfaces.City;
    using World.Data.EF.Context;
    public class CityRepository:ICityRepository
    {
        private readonly WorldDbContext _worldDbContext;
        public CityRepository(WorldDbContext worldDbContext)
        {
            _worldDbContext = worldDbContext;
        }

        public async Task<int> AddCityAsync(City city)
        {
            var country = await _worldDbContext.Countries.FindAsync(city.Country.Id);
            city.UpdateCountry(country);
            try
            {
                await _worldDbContext.AddAsync(city);
                await _worldDbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw e;
            }

            return city.Id;
        }

        public async Task<List<City>> GetAllCitiesAsync(int pageNumber = 1, int pageSize = 20)
        {
            if(pageNumber == 0)
            {
                pageNumber = 0;
            }
            else
            {
                pageNumber = pageNumber - 1;
            }
            if(pageSize == 0)
            {
                pageSize = 20;
            }
            return await _worldDbContext.Cities
                .Skip(pageNumber*pageSize)
                .Take(pageSize)
                .Include(c => c.Country).ToListAsync();
        }
    }
}
