

namespace World.Core.Interfaces.City
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using World.Core.DomainEntities.Cities;
    public interface ICityRepository
    {
        Task<int> AddCityAsync(City city);
        Task<List<City>> GetAllCitiesAsync(int pageNumber, int pageSize);
    }
}
