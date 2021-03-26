
namespace World.Data.Repository.CityRepositories
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;
    using World.Core.DomainEntities.Cities;
    using World.Core.DomainEntities.Paging;
    using World.Core.Interfaces.City;
    using World.Data.EF.Context;
    using World.Data.Repository.PagingRepository;

    public class CityRepository:ICityRepository
    {
        private readonly WorldDbContext _worldDbContext;
        public CityRepository(WorldDbContext worldDbContext)
        {
            _worldDbContext = worldDbContext;
        }
        public async Task<bool> IsDupeCity(City city)
        {
            var country = await _worldDbContext.Countries.FindAsync(city.Country.Id);
            city.UpdateCountry(country);

            bool isDupeCity = await _worldDbContext.Cities.AnyAsync(c => c.Name == city.Name
                                                          && c.Latitude == city.Latitude
                                                          && c.Longtitude == city.Longtitude
                                                          //check for country
                                                          && c.Country.Id == country.Id);
            return isDupeCity;
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

        public async Task<PaginationResult<City>> GetAllCitiesAsync(PagingParams pagingParams,
            string sortColumn = null,
            string sortOrder = null,
            string filterColumn = null,
            string filterQuery = null)
        {
            var queryableCity = _worldDbContext.Cities.AsQueryable();
            return await queryableCity.Include(c => c.Country).GetPagedResultAsync(pagingParams.PageNumber, 
                pagingParams.PageSize,sortColumn,sortOrder,filterColumn,filterQuery);
        }

        public async Task<bool> IsDupeCityAsync(City city)
        {
            var country = await _worldDbContext.Countries.FindAsync(city.Country.Id);
            bool isDupeCity = await _worldDbContext.Cities.AnyAsync(c => c.Name == city.Name
                                                                      && c.Latitude == city.Latitude
                                                                      && c.Longtitude == city.Longtitude
                                                                      //check for country
                                                                      && c.Country.Id == country.Id );
            return isDupeCity;
        }
    }
}
