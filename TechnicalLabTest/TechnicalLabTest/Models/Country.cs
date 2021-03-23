using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalLabTest.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PersonalInformation> PersonalInformations { get; set; }
        public List<City> Cities { get; set; }
    }
}
