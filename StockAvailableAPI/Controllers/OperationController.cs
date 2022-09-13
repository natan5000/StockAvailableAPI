using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockAvailableAPI.Data;
using StockAvailableAPI.Models;

namespace StockAvailableAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly DataContext _context;

        public OperationController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Operation>>> GetAll()
        {
            return Ok(await _context.operations.ToListAsync());
        }


        [HttpGet("code")]
        public IActionResult GetCode(string code)
        {
            try
            {
                var ope = _context.operations.ToList();
                if (code != null)
                {
                    ope = ope.Where(x => x.codeBox.ToLower().IndexOf(code) > -1).ToList();
                }
                return Ok(ope);
            }
            catch
            {
                return BadRequest("Product not found!");
            }
        }
    }

}
