using MAUIAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MAUIAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public EventsController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet("{countryId}")]
        public async Task<ActionResult<List<EventItem>>> GetEventsByCountryId(int countryId)
        {
            var events = await _context.ListofEventsData
                                       .Where(e => e.FKiCountryDataId == countryId && e.iStatus==10)
                                       .ToListAsync();
            foreach (var item in events)
            {
                DocumentsFilepathController ImgFilePath = new DocumentsFilepathController(_context, _configuration);
                var ImgID = Convert.ToInt32(item.sImages);
                item.ImagePath = ImgFilePath.FilePath(ImgID);
                Console.WriteLine("ImgResult ID: " + item.ImagePath);
            }

            return Ok(events);
        }
    }

}
