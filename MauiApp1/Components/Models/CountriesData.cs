using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Components.Models
{
    public class CountriesData
    {
        public int id { get; set; }
        public string sName { get; set; } = string.Empty;
        public int fKiCountryID { get; set; }
        public int? iStatus { get; set; }
        public string sImages { get; set; } = string.Empty;
        public string? imagePath { get; set; }

    }
}
