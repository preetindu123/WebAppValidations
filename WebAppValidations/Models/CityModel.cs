using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppValidations.Models
{
    public class CityModel : CountryModel
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
       
    }
}
