using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Components.Models
{
    public class EventItem
    {
        public int ID { get; set; }
        public int FKiCountryDataId { get; set; }
        public string? sName { get; set; }
        public string? sTitle { get; set; }
        public string? sImages { get; set; }
        public string? ImagePath { get; set; }
    }
}
