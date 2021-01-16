using System;
using System.Collections.Generic;
using System.Text;

namespace World.Api.Models.Country
{
    public class GetCountriesOutputModel
    {
        public List<CountryModel>  Countries { get; set; }
        public static GetCountriesOutputModel Create(List<CountryModel> countries)
        {
            return new GetCountriesOutputModel
            {
                Countries = countries
            };
        }
    }
}
