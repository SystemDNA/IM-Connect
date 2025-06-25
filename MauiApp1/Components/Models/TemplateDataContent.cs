using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Components.Models
{
    public class TemplateDataContent
    {
        public int ID { get; set; }
        public string? sContent { get; set; }
        public int FKiCountryID { get; set; }
        public int FKiEventID { get; set; }
    }
}
