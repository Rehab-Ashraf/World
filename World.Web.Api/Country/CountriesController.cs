
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
    using World.Core.DomainEntities.Paging;

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
        public async Task<IActionResult> GetAllCountriesAsync([FromQuery] PagingParams pagingParams,
            string sortColumn = null,
            string sortOrder = null,
            string filterColumn = null,
            string filterQuery = null)
        {
            var countries = await _countryService.GetCountriesAsync(pagingParams,sortColumn,sortOrder , filterColumn , filterQuery);
            var countryModel = _mapper.Map<List<CountryModel>>(countries.Result);
            var result = GetCountriesOutputModel.Create(countryModel , countries);
            return Ok(ResponseResult.SucceededWithData(result));
        }
    }
}
