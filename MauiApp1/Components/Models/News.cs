using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Components.Models
{
    public class News
    {
        public int id { get; set; }
        public int fkiCategoryId { get; set; }
        public string? sName { get; set; }
        public string? sContent { get; set; }
        public int fkiCountryID { get; set; }
        public int fkiDataID { get; set; }
        public bool isExpanded { get; set; } = false;
        public DateTime? xicreatedWhen { get; set; }
        public string? imagePath { get; set; }
    }
    public class NewsContent
    {
        public int id { get; set; }
        public int? fkiNewsID { get; set; }
        public string? sName { get; set; }
        public string? sTitle { get; set; }
        public string? sContent { get; set; }
    }
}
