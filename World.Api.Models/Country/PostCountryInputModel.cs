using System;
using System.Collections.Generic;
using System.Text;

namespace World.Api.Models.Country
{
    public class PostCountryInputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //country code
        public string ISO2 { get; set; }
        //country code
        public string ISO3 { get; set; }
    }
}
