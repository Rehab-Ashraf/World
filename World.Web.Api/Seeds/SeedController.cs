
namespace World.Web.Api.Seeds
{
    using AutoMapper;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using OfficeOpenXml;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using World.Core.Interfaces.City;
    using World.Core.Interfaces.Country;
    using World.Core.DomainEntities.Countries;
    using World.Api.Models.Country;
    using World.Api.Models.City;
    using World.Core.DomainEntities.Cities;


    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;
        private readonly IWebHostEnvironment _env;
        public SeedController(IMapper mapper, ICountryService countryService , ICityService cityService, IWebHostEnvironment env)
        {
            _mapper = mapper;
            _countryService = countryService;
            _cityService = cityService;
            _env = env;
        }
        [HttpGet]
        public async Task<IActionResult> Import()
        {
            // If you are a commercial business and have
            // purchased commercial licenses use the static property
            // LicenseContext of the ExcelPackage class:
            ExcelPackage.LicenseContext = LicenseContext.Commercial;

            // If you use EPPlus in a noncommercial context
            // according to the Polyform Noncommercial license:
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var path = Path.Combine(_env.ContentRootPath, String.Format("Source/worldcities.xlsx"));
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                
                using (var ep = new ExcelPackage(stream))
                {                    
                    // get the first worksheet                   
                    var ws = ep.Workbook.Worksheets[0];
                   // initialize the record counters
                    var nCountries = 0;                   
                    var nCities = 0;
                    #region Import all Countries                    
                    // create a list containing all the countries                    
                    // already existing into the Database (it                    
                    // will be empty on first run).            
                    var countries = await _countryService.GetCountriesAsync();
                    //var countryModel = _mapper.Map<List<CountryModel>>(countries);
                    var lstCountries = countries;
                    // iterates through all rows, skipping the                    
                    // first one                    
                    for (int nRow = 2;nRow <= ws.Dimension.End.Row;nRow++)
                    {                        
                        var row = ws.Cells[nRow, 1, nRow,ws.Dimension.End.Column]; 
                        var name = row[nRow, 5].GetValue<string>();
                        // Did we already created a country with 
                        // that name?                        
                        if (lstCountries.Where(c => c.Name == name).Count() == 0)     
                        {                            
                            // create the Country entity and fill it
                            // with xlsx data 
                            var model = new PostCountryInputModel();
                            model.Name = name;
                            model.ISO2 = row[nRow,6].GetValue<string>();
                            model.ISO3 = row[nRow,7].GetValue<string>();
                            // save it into the Database                            
                            var country = _mapper.Map<Country>(model);

                            var result = await _countryService.AddCountryAsync(country);
                            // store the country to retrieve                            
                            // its Id later on                            
                            lstCountries.Add(country);
                            // increment the counter                            
                            nCountries++;                        
                        }                    
                    }
                    #endregion
                    #region Import all Cities                    
                    // iterates through all rows, skipping the                    
                    // first one                    
                    for (int nRow = 2;nRow <= ws.Dimension.End.Row;nRow++)                    
                    {                        
                        var row = ws.Cells[nRow, 1, nRow,ws.Dimension.End.Column];
                        // create the City entity and fill it                        
                        // with xlsx data                        
                        var model = new PostCityInoutModel();                        
                        model.Name = row[nRow, 1].GetValue<string>();                       
                        model.Name_ASCII = row[nRow,2].GetValue<string>(); 
                        model.Latitude = row[nRow, 3].GetValue<decimal>();                        
                        model.Longtitude = row[nRow, 4].GetValue<decimal>();
                        // retrieve CountryId                        
                        var countryName = row[nRow,5].GetValue<string>();
                        var country = lstCountries.Where(c => c.Name == countryName).FirstOrDefault();
                        model.CountryId = country.Id;
                        // save the city into the Database                       
                        var city = _mapper.Map<City>(model);
                        var result = await _cityService.AddCityAsync(city);
                        // increment the counter                        
                        nCities++;                    
                    }                    
                    #endregion
                    return new JsonResult(new { Cities = nCities, Countries = nCountries });
                }

            }
        }
    }
}