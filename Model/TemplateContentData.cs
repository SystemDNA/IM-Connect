using System.ComponentModel.DataAnnotations.Schema;

namespace MAUIAPI.Model
{
    [Table("IMContentTemplate_T")]
    public class TemplateContentData
    {
        public int ID { get; set; }
        public string? sContent { get; set; }
        public int FKiCountryID { get; set; }
        public int FKiEventID { get; set; }
    }
}
