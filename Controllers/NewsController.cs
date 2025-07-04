using MAUIAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;

namespace MAUIAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public NewsController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet("{EventID:int}/{CountryID:int}")]
        public async Task<ActionResult<List<News>>> GetNewsContentList(int EventID, int CountryID)
        {
            List<News> events = new List<News>();
            if (EventID > 0)
            {
                events = await _context.News
                                          .Where(e => e.FKiDataID == EventID && e.iStatus == 10)
                                          .ToListAsync();
            }
            else if (CountryID > 0)
            {
                events = await _context.News
                                          .Where(e => e.FKiCountryID == CountryID && e.FKiDataID==EventID && e.iStatus == 10)
                                          .ToListAsync();
            }
            foreach (var item in events)
            {
                DocumentsFilepathController ImgFilePath = new DocumentsFilepathController(_context, _configuration);
                var ImgID = Convert.ToInt32(item.sImages);
                item.ImagePath = ImgFilePath.FilePath(ImgID);
                Console.WriteLine("ImgResult ID: " + item.ImagePath);
            }

            return Ok(events);
        }
        [HttpGet("newscontent/{EventID:int}")]
        public async Task<ActionResult<List<NewsContent>>> GetContent(int EventID)
        {
            var events = await _context.NewsContent
                                       .Where(e => e.FKiNewsID == EventID && e.iStatus==10)
                                       .ToListAsync();

            return Ok(events);
        }
    }
}
