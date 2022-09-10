using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockAvailableAPI.Data;
using StockAvailableAPI.Models;

namespace StockAvailableAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            return Ok(await _context.products.ToListAsync());
        }

        [HttpGet("code")]
        public IActionResult GetCode(string code)
        {
            try 
            {
                var prod = _context.products.ToList();
                if(code != null)
                {
                    prod = prod.Where(x => x.code.ToLower().IndexOf(code) > -1).ToList();
                }
                return Ok(prod);
            }
            catch
            {
                return BadRequest("Product not found!");
            }
        }

       [HttpPost]
       public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            _context.products.Add(product);
            await _context.SaveChangesAsync();
            return Ok(await _context.products.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateProduct(Product request)
        {
            var dbProduct = await _context.products.FindAsync(request.Id);
            if (dbProduct == null)
                return BadRequest("Product not found!");

            dbProduct.code = request.code;
            dbProduct.name = request.name;
            dbProduct.active = request.active;
            await _context.SaveChangesAsync();

            return Ok(await _context.products.ToListAsync());
        }

    }
}
