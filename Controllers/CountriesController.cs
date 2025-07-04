using MAUIAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace MAUIAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        public CountriesController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountriesList>>> GetAll()
        {
            try
            {
                var CountryData= await _context.ListofCountries.Where(k=>k.iStatus==10).ToListAsync();

                foreach(var item in CountryData)
                {
                    DocumentsFilepathController ImgFilePath = new DocumentsFilepathController(_context, _configuration);
                    var ImgID = Convert.ToInt32(item.sImages);
                    item.ImagePath= ImgFilePath.FilePath(ImgID);
                    Console.WriteLine("ImgResult ID: " + item.ImagePath);
                }
                return CountryData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
