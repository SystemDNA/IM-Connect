using MAUIAPI;
using MAUIAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Products>>> GetAll()
    {
        try
        {
            return await _context.Products.ToListAsync();
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    // POST: api/products
    [HttpPost]
    public async Task<ActionResult<Products>> AddProduct(Products product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAll), new { id = product.ID }, product);
    }
}
