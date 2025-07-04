using System.ComponentModel.DataAnnotations.Schema;

namespace MAUIAPI.Model
{
    [Table("IMEventData_T")]
    public class EventItem
    {
        public int ID { get; set; }
        public int FKiCountryDataId { get; set; }
        public string? sName { get; set; }
        public string? sTitle { get; set; }
        public string? sImages { get; set; }
        [NotMapped]
        public string? ImagePath { get; set; }
        public int? iStatus { get; set; }
    }

}
