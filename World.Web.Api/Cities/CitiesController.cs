


namespace World.Web.Api.Cities
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using World.Api.Models;
    using World.Api.Models.City;
    using World.Core.DomainEntities.Cities;
    using World.Core.DomainEntities.Paging;
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
            var isDupeCity = await _cityService.IsDupeCityAsync(city);
            if (isDupeCity)
            {
                string message = $"{city.Name} city is already exist";
                return BadRequest(ResponseResult.SucceededWithData(message));
            }

            var result = await _cityService.AddCityAsync(city);
            return Ok(ResponseResult.SucceededWithData(result));
        }

        [HttpPost]
        [Route("IsDupeCity")]
        public async Task<IActionResult> IsDupeCity(PostCityInoutModel model)
        {
            var city = _mapper.Map<City>(model);
            var isDupeCity = await _cityService.IsDupeCityAsync(city);
            string message = "";
            if (isDupeCity)
            {
                message = $"{city.Name} city is already exist";
                return BadRequest(ResponseResult.SucceededWithData(message));
            }
            message = $"{city.Name} city is not exist";

            return Ok(ResponseResult.SucceededWithData(message));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCitiesAsync([FromQuery]PagingParams paginfParams,
                                                           string sortColumn = null,
                                                           string sortOrder = null,
                                                           string filterColumn = null,
                                                           string filterQuery = null)
       {
            var cities =
                await _cityService.GetAllCitiesAsync(paginfParams, sortColumn, sortOrder, filterColumn, filterQuery);
            var citiesModel = _mapper.Map<List<CityModel>>(cities.Result);
            var result = GetCitiesOutPutModel.Create(citiesModel , cities);
            return Ok(ResponseResult.SucceededWithData(result));
        }
    }
}
