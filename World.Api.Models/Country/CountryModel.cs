﻿using System;
using System.Collections.Generic;
using System.Text;

namespace World.Api.Models.Country
{
    public class CountryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISO2 { get; set; }
        public string ISO3 { get; set; }

        public static CountryModel New(int id , string name ,string iso2 , string iso3)
        {
            return new CountryModel
            {
                Id = id,
                Name = name,
                ISO2 = iso2,
                ISO3 = iso3

            };
        }
    }
}
