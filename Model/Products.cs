using System.ComponentModel.DataAnnotations.Schema;

namespace MAUIAPI.Model
{
    [Table("Products_T")]
    public class Products
    {
        public int ID { get; set; }
        public string sName { get; set; }
        public decimal rPrice { get; set; }
    }
}
