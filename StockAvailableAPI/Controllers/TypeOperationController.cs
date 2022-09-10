using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockAvailableAPI.Data;
using StockAvailableAPI.Models;

namespace StockAvailableAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOperationController : ControllerBase
    {
        private readonly DataContext _context;
        public TypeOperationController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TypeOperation>>> GetAll()
        {
            return Ok(await _context.typeOperations.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<TypeOperation>>> AddTypeOperations(TypeOperation type)
        {
            _context.typeOperations.Add(type);
            await _context.SaveChangesAsync();
            return Ok(await _context.typeOperations.ToListAsync());
        }
    }
}
