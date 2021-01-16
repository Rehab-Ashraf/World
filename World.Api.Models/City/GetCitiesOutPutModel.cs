using System;
using System.Collections.Generic;
using System.Text;

namespace World.Api.Models.City
{
    public class GetCitiesOutPutModel
    {
        public List<CityModel> Cities { get; set; }
        public static GetCitiesOutPutModel Create(List<CityModel> cities)
        {
            return new GetCitiesOutPutModel
            {
                Cities = cities
            };
        }


    }
}
