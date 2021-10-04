using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BE_Drink.Models;
using BE_Drink.DbContext;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace BE_Drink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly BE_DrinkContext _context;
        private readonly IConfiguration _configuration;

        public ProductsController(BE_DrinkContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        //GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductTable>>> Getproducts()
        {
            return await _context.products.ToListAsync();
        }

        [Route("GetImgProductFeature/{id}")]
        [HttpGet]
        public JsonResult GetImgProductFeature(long id)
        {

            string query = @"
                            select * from ImgProductFeature
                            where ImgProductFeature.product_id = " + id;
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("BE_DrinkContext");
            SqlDataReader myRender;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myRender = myCommand.ExecuteReader();
                    table.Load(myRender);
                    myRender.Close(); myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        //GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductTable>> GetProduct(long id)
        {
            var product = await _context.products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(long id, ProductTable product)
        {
            if (id != product.id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductTable>> PostProduct(ProductTable product)
        {
            _context.products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            var product = await _context.products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(long id)
        {
            return _context.products.Any(e => e.id == id);
        }

    }
}
