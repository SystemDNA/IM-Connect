using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Components.Models
{
    public class News
    {
        public int ID { get; set; }
        public int FKiCategoryId { get; set; }
        public string? sName { get; set; }
        public string? sContent { get; set; }
        public int FKiCountryID { get; set; }
        public int FKiDataID { get; set; }
        public bool IsExpanded { get; set; } = false;
    }
    public class NewsContent
    {
        public int ID { get; set; }
        public int? FKiNewsID { get; set; }
        public string? sName { get; set; }
        public string? sTitle { get; set; }
        public string? sContent { get; set; }
    }
}
