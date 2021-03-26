using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using World.Core.DomainEntities.Cities;
using World.Core.DomainEntities.Paging;
using World.Core.Interfaces.City;

namespace World.Services.CityServices
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public async Task<int> AddCityAsync(City city)
        {
            return await _cityRepository.AddCityAsync(city);
        }

        public async Task<PaginationResult<City>> GetAllCitiesAsync(PagingParams pagingParams,
                                                                    string sortColumn,
                                                                    string sortOrder,
                                                                    string filterColumn,
                                                                    string filterQuery)
        {
            return await _cityRepository.GetAllCitiesAsync(pagingParams,sortColumn,sortOrder,filterColumn,filterQuery);
        }

        public async Task<bool> IsDupeCityAsync(City city)
        {
            return await _cityRepository.IsDupeCityAsync(city);
        }
    }
}
