using MAUIAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MAUIAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesDataController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        public CountriesDataController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        // In CountriesDataController.cs
        [HttpGet("{countryId}")]
        public async Task<ActionResult<IEnumerable<CountriesData>>> GetByCountryId(int countryId)
        {
            var result = await _context.ListofCountriesData
                .Where(c => c.FKiCountryID == countryId && c.iStatus==10)
                .ToListAsync();

            foreach (var item in result)
            {
                DocumentsFilepathController ImgFilePath = new DocumentsFilepathController(_context, _configuration);
                var ImgID = Convert.ToInt32(item.sImages);
                item.ImagePath = ImgFilePath.FilePath(ImgID);
                Console.WriteLine("ImgResult ID: " + item.ImagePath);
            }

            return Ok(result);
        }

    }
}
