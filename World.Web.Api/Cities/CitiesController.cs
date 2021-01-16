


namespace World.Web.Api.Cities
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using World.Api.Models;
    using World.Api.Models.City;
    using World.Core.DomainEntities.Cities;
    using World.Core.Interfaces.City;

    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICityService _cityService;
        public CitiesController(IMapper mapper , ICityService cityService)
        {
            _mapper = mapper;
            _cityService = cityService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCityAsync(PostCityInoutModel model)
        {
            var city = _mapper.Map<City>(model);
            var result = await _cityService.AddCityAsync(city);
            return Ok(ResponseResult.SucceededWithData(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCitiesAsync(int pageNumber , int pageSize)
        {
            var cities = await _cityService.GetAllCitiesAsync(pageNumber,pageSize);
            var cityModel = _mapper.Map<List<CityModel>>(cities);
            var result = GetCitiesOutPutModel.Create(cityModel);
            return Ok(ResponseResult.SucceededWithData(result));
        }
    }
}
