using System;
using System.Collections.Generic;
using System.Text;
using World.Core.DomainEntities.Countries;

namespace World.Core.DomainEntities.Cities
{
    public class City:DomainEntity<int>
    {
        public string Name { get; private set; }
        public string Name_ASCII { get; private set; }
        public decimal Latitude { get; private set; }
        public decimal Longtitude { get; private set; }
        public Country Country { get; private set; }
        public static City CreateWithId(int id) => new City { Id = id };

        public City UpdateBasicData(City city)
        {
            Name = city.Name;
            Name_ASCII = city.Name_ASCII;
            Latitude = city.Latitude;
            Longtitude = city.Longtitude;

            return this;
        }
        public City UpdateCountry(Country country)
        {
            Country = country;
            return this;
        }
    }
}
