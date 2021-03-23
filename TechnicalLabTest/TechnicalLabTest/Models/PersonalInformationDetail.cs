using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalLabTest.Models
{
    public class PersonalInformationDetail
    {
        public int Id { get; set; }
        public int PersonalInformationId { get; set; }
        public int LanguageId { get; set; }
        [NotMapped]
        public string LanguageName { get; set; }

        [NotMapped]
        public bool IsChecked { get; set; }

        public Language Language { get; set; }
        public PersonalInformation PersonalInformation { get; set; }
    }
}
