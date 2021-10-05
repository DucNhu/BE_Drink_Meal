using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BE_Drink.DbContext;
using BE_Drink.Models.BlogF;
using BE_Drink.Models.Blog;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BE_Drink.Controllers.Blogf
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetarialsController : ControllerBase
    {
        private readonly BE_DrinkContext _context;
        private readonly IConfiguration _configuration;

        public MetarialsController(BE_DrinkContext context)
        {
            _context = context;
        }

        // GET: api/Metarials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Metarial>>> Getmetarials()
        {
            return await _context.metarials.ToListAsync();
        }

        // GET: api/Metarials/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Metarial>> GetMetarial(long id)
        //{
        //    var metarial = await _context.metarials.FindAsync(id);

        //    if (metarial == null)
        //    {
        //        return NotFound();
        //    }

        //    return metarial;
        //}

        [Route("GetMetarial/{id}")]
        [HttpGet]
        public JsonResult GetMetarial(long id)
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

        // PUT: api/Metarials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetarial(long id, Metarial metarial)
        {
            if (id != metarial.id)
            {
                return BadRequest();
            }

            _context.Entry(metarial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetarialExists(id))
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

        // POST: api/Metarials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Metarial>> PostMetarial(Metarial metarial)
        {
            _context.metarials.Add(metarial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMetarial", new { id = metarial.id }, metarial);
        }

        //[HttpPost]
        //public async Task<ActionResult> PostListMetarial([FromBody]listMetarial listMetarials)
        //{
        //     Console.WriteLine(listMetarials);
        //    //foreach (var item in listMetarials)
        //    //{
        //    ////    _context.metarials.Add(item);
        //    //await _context.ksaveChangesAsync();

        //    //await CreatedAtAction("GetMetarial", new { id = metarial.id }, metarial);
        //    //}

        //    return Ok();
        //}
        // DELETE: api/Metarials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMetarial(long id)
        {
            var metarial = await _context.metarials.FindAsync(id);
            if (metarial == null)
            {
                return NotFound();
            }

            _context.metarials.Remove(metarial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MetarialExists(long id)
        {
            return _context.metarials.Any(e => e.id == id);
        }
    }
}
