using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Components.Models
{
    public class EventItem
    {
        public int id { get; set; }
        public int fKiCountryDataId { get; set; }
        public int fKiCountryID { get; set; }
        public string? sName { get; set; }
        public string? sTitle { get; set; }
        public string? sImages { get; set; }
        public string? imagePath { get; set; }
    }
    public class ExpandingData
    {
        public int id { get; set; }
        public int fKiTemplateID { get; set; }
        public string? sName { get; set; }
        public string? sFullContent { get; set; }
    }
}
