using System.ComponentModel.DataAnnotations.Schema;

namespace MAUIAPI.Model
{
    [Table("IMNews_T")]
    public class News
    {
        public int ID { get; set; }
        public int FKiCategoryId { get; set; }
        public string? sName { get; set; }
        public string? sContent { get; set; }
        public int FKiCountryID { get; set; }
        public int FKiDataID { get; set; }
        public int sImages {  get; set; }
        [NotMapped]
        public string? ImagePath { get; set; }
        public int? iStatus { get; set; }
        public DateTime? XICreatedWhen { get; set; }

    }
    [Table("IMNewsContent_T")]
    public class NewsContent
    {
        public int ID { get; set; }
        public int? FKiNewsID { get; set; }
        public string? sName { get; set; }
        public string? sTitle { get; set; }
        public string? sContent { get; set; }
        [NotMapped]
        public string? ImagePath { get; set; }
        public int? iStatus { get; set; }
    }
}
