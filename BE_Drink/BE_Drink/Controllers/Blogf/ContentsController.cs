using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BE_Drink.DbContext;
using BE_Drink.Models.BlogF;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BE_Drink.Controllers.Blogf
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentsController : ControllerBase
    {
        private readonly BE_DrinkContext _context;
        private readonly IConfiguration _configuration;

        public ContentsController(BE_DrinkContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/Contents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Content>>> Getcontents()
        {
            return await _context.contents.ToListAsync();
        }

        // GET: api/Contents/5
        [Route("GetContent/{id}")]
        [HttpGet]
        public JsonResult GetContent(long id)
        {

            string query = @"
                            select * from contents where contents.blog_id =  " + id;
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

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Content>> GetContent(long id)
        //{
        //    var content = await _context.contents.FindAsync(id);

        //    if (content == null)
        //    {
        //        return NotFound();
        //    }

        //    return content;
        //}

        // PUT: api/Contents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContent(long id, Content content)
        {
            if (id != content.id)
            {
                return BadRequest();
            }

            _context.Entry(content).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentExists(id))
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

        // POST: api/Contents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Content>> PostContent(Content content)
        {
            _context.contents.Add(content);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContent", new { id = content.id }, content);
        }

        // DELETE: api/Contents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContent(long id)
        {
            var content = await _context.contents.FindAsync(id);
            if (content == null)
            {
                return NotFound();
            }

            _context.contents.Remove(content);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContentExists(long id)
        {
            return _context.contents.Any(e => e.id == id);
        }
    }
}
