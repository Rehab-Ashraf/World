using System;
using System.Collections.Generic;
using System.Text;

namespace World.Api.Models.City
{
    public class CityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Name_ASCII { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longtitude { get; set; }
        public int CountryId { get; set; }


        public static CityModel New(int id , string name , string name_ascii , decimal latitude , decimal longtitude , int countryId)
        {
            return new CityModel
            {
                Id = id,
                Name = name,
                Name_ASCII = name_ascii,
                Latitude = latitude,
                Longtitude = longtitude,
                CountryId = countryId
            };
        }
    }
}
