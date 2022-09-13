using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockAvailableAPI.Data;
using StockAvailableAPI.Models;

namespace StockAvailableAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoxController : ControllerBase
    {
        private readonly DataContext _context;

        public BoxController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Box>>> GetAll()
        {
            return Ok(await _context.boxes.ToListAsync());
        }

        [HttpGet("productId")]
        public async Task<ActionResult<List<Box>>> Get(int productId)
        {
            var boxes = await _context.boxes
                .Where(c => c.productId == productId)
                .ToListAsync();

            return boxes;
        }

    }
}
