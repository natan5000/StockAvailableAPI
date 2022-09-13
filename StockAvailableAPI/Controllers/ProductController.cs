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
        [Route("GetStockAvailable")]
        public async Task<IActionResult> GetStockAvailable()
        {
                    var command = _context.Database.GetDbConnection().CreateCommand();
                    command.CommandText = "SELECT  p.Id, p.code,(SELECT TOP 1[date]  FROM operations c INNER JOIN boxes b ON c.codeBox = b.code WHERE c.codeBox = b.code ORDER BY c.Id DESC) AS date_last, ISNULL((SELECT SUM(c.quantity) FROM operations c INNER JOIN typeOperations to2 ON c.typeOperationID = to2.id INNER JOIN boxes b ON p.Id = b.productId WHERE c.codeBox = b.code AND to2.[type] = 1), 0) - ISNULL((SELECT SUM(c.quantity) FROM operations c INNER JOIN typeOperations to3 ON c.typeOperationID = to3.id INNER JOIN boxes b ON p.Id = b.productId WHERE c.codeBox = b.code AND to3.[type] = 2), 0) as stock FROM products p GROUP BY p.code, p.Id";
                    _context.Database.OpenConnection();
                    var result = command.ExecuteReader();

                    List<stockAvailable> lista = new();
                    while (result.Read())
                    {
                       stockAvailable item = new();
                item.Id = Convert.ToInt32(result["id"]);
                item.code = (string)result["code"];
                item.date = Convert.ToDateTime(result["date_last"]);
                item.qty = Convert.ToInt32(result["stock"]);
                lista.Add(item);
            }

            result.Close();
            return Ok(lista);

        }
        [HttpGet]
        [Route("productDetails/{productId}")]
        public async Task<IActionResult> productDetails(int productId)
        {
            var command = _context.Database.GetDbConnection().CreateCommand();
            command.CommandText = "SELECT b.code,(SELECT TOP 1[date]  FROM operations AS c WHERE c.codeBox = b.code ORDER BY id DESC) AS date_last, (SELECT SUM(quantity) FROM operations AS c JOIN (SELECT * FROM typeOperations) AS D ON c.typeOperationID = D.id WHERE c.codeBox = b.code AND D.[type] = 1 ) - ISNULL((SELECT SUM(quantity) FROM operations AS v JOIN (SELECT * FROM typeOperations) AS D ON v.typeOperationID = D.id WHERE v.codeBox = b.code AND D.[type] = 2), 0) AS stock FROM boxes b INNER JOIN products p ON p.id = b.productId WHERE b.productId = " + productId + "";
            _context.Database.OpenConnection();
            var result = command.ExecuteReader();

            List<productDetails> lista = new();
            while (result.Read())
            {
                productDetails item = new();
                item.code = (string)result["code"];
                item.date_last = Convert.ToDateTime(result["date_last"]);
                item.stock = Convert.ToInt32(result["stock"]);
                lista.Add(item);
            }

            result.Close();
            return Ok(lista);

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
