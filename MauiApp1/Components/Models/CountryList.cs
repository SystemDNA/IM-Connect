using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Components.Models
{
    public class CountryLists
    {
        public int ID { get; set; }
        public string sCountryName { get; set; } = string.Empty;
        public int? iStatus { get; set; }
        public string? sImages { get; set; }
        public string? ImagePath { get; set; }
    }
}
