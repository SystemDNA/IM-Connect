using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Components.Models
{
    public class TemplateDataContent
    {
        public int id { get; set; }
        public string? sContent { get; set; }
        public int fKiCountryID { get; set; }
        public int fKiEventID { get; set; }
        public int? sImages {  get; set; }
        public string? imagePath { get; set; }
    }
}
