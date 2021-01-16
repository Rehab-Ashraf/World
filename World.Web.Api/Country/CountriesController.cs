
namespace World.Web.Api.Country
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using World.Api.Models.Country;
    using World.Core.Interfaces.Country;
    using World.Core.DomainEntities.Countries;
    using World.Api.Models;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICountryService _countryService;
        public CountriesController(IMapper mapper , ICountryService countryService)
        {
            _mapper = mapper;
            _countryService = countryService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCountryAsync(PostCountryInputModel model)
        {

            var country = _mapper.Map<Country>(model);

            var result = await _countryService.AddCountryAsync(country);
            
            return Ok(ResponseResult.SucceededWithData(result));

        }

        [HttpGet]
        public async Task<IActionResult> GetAllCountriesAsync()
        {
            var countries = await _countryService.GetCountriesAsync();
            var countryModel = _mapper.Map<List<CountryModel>>(countries);
            var result = GetCountriesOutputModel.Create(countryModel);
            return Ok(ResponseResult.SucceededWithData(result));
        }
    }
}
