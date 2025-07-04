using System.ComponentModel.DataAnnotations.Schema;

namespace MAUIAPI.Model
{
    [Table("IMCountriesList_T")]
    public class CountriesList
    {
        public int ID {  get; set; }
        public string sCountryName { get; set; } = string.Empty;
        public int? iStatus { get; set; }
        public string? sImages { get; set; }

        [NotMapped]
        public string? ImagePath { get; set; }
    }
    
    
}
