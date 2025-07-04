using System.ComponentModel.DataAnnotations.Schema;

namespace MAUIAPI.Model
{
    [Table("IMCountriesData_T")]
    public class CountriesData
    {
        public int ID { get; set; }
        public string sName { get; set; } = string.Empty;
        public int FKiCountryID { get; set; }
        public int? iStatus { get; set; }
        public string sImages { get; set; } = string.Empty;
        //public string sFilePath { get; set; } = string.Empty;
        [NotMapped]
        public string? ImagePath {  get; set; }

    }
}
