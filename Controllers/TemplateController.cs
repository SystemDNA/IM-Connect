using MAUIAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MAUIAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemplateController : Controller
    {
        private readonly AppDbContext _context;

        public TemplateController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("{EventID:int}/{CountryID:int}")]
        public async Task<ActionResult<List<TemplateContentData>>> GetContentList(int EventID, int CountryID)
        {
            var events = await _context.TemplateContentData
                                       .Where(e => e.FKiCountryID == CountryID && e.FKiEventID == EventID)
                                       .ToListAsync();

            return Ok(events);
        }
    }
}
