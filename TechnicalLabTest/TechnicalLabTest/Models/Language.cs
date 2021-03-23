using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalLabTest.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PersonalInformationDetail> PersonalInformationDetails { get; set; }
    }
}
