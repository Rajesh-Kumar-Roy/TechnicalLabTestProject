using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TechnicalLabTest.Models
{
    public class PersonalInformation
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int CountryId { get; set; }
        [NotMapped]
        public string CountryName { get; set; }
        public int CityId { get; set; }
        [NotMapped]
        public string CityName { get; set; }
       
        public List<PersonalInformationDetail> PersonalInformationDetails { get; set; }
  
        public DateTime DateTime { get; set; }
        public byte[] File { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
    }
}
