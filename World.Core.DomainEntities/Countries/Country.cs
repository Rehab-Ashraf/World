

using System.Collections.Generic;
using World.Core.DomainEntities.Cities;

namespace World.Core.DomainEntities.Countries
{
    public class Country : DomainEntity<int>
    {
        public string Name { get; private set; }
        //country code
        public string ISO2 { get; private set; }
        //country code
        public string ISO3 { get; private set; }

        public virtual ICollection<City> Cities { get; set; }
        public static Country Create(int id, string name, string iso2 , string iso3)
        {
            return new Country
            {
                Name = name,
                ISO2 = iso2 ,
                ISO3 = iso3
            };
        }
        public static Country CreateWithId(int id) => new Country
        {
            Id = id
        };

        public Country UpdateBasicData(Country country)
        {
            Name = country.Name;
            ISO2 = country.ISO2;
            ISO3 = country.ISO3;
            return this;
        }
    }
}
