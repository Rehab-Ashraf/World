using System;
using System.Collections.Generic;
using System.Text;

namespace World.Api.Models.City
{
    public class PostCityInoutModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Name_ASCII { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longtitude { get; set; }
        public int CountryId { get; set; }
    }
}
