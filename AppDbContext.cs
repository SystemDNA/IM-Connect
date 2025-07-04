using MAUIAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace MAUIAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Products> Products { get; set; }
        public DbSet<CountriesList> ListofCountries { get; set; }
        public DbSet<CountriesData> ListofCountriesData { get; set; }
        public DbSet<EventItem> ListofEventsData { get; set; }
        public DbSet<TemplateContentData> TemplateContentData { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsContent> NewsContent { get; set; }
        public DbSet<Documents> Documents { get; set; }
    }
}
