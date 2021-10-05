using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BE_Drink.DbContext;
using BE_Drink.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BE_Drink.Controllers.Blogf
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogeresController : ControllerBase
    {
        private readonly BE_DrinkContext _context;
        private readonly IConfiguration _configuration;

        public BlogeresController(BE_DrinkContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/Blogeres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bloger>>> GetBloger()
        {
            return await _context.Blogers.ToListAsync();
        }

        // GET: api/Blogeres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bloger>> GetBloger(long id)
        {
            var Bloger = await _context.Blogers.FindAsync(id);

            if (Bloger == null)
            {
                return NotFound();
            }

            return Bloger;
        }
//        [Route("GetBloger/{id}")]
//        [HttpGet]
//        public JsonResult GetBloger(long id)
//        {

//            string query = @"
//                            select 
//Blogers.banner_img,
//Blogers.cooking_time,
//Blogers.category_id,
//Blogers.cover_img,
//Blogers.create_at,
//Blogers.create_at,
//Blogers.description,
//Blogers.id,
//Blogers.name,
//Blogers.status,
//Blogers.summary,
//Blogers.update_at,
//Blogers.url_video_utube,
//Blogers.user_id,
//Blogers.[view],

//contents.name as 'content_name',
//contents.banner_cover as 'content_banner_cover',
//contents.banner_img as 'content_banner_img',
//contents.content as 'content_content',
//contents.id as 'content_content',

//metarials.id as 'metarials_id',
//metarials.mass as 'metarials_mass',
//metarials.title as 'metarials_title',
//metarials.unit as 'metarials_unit',
//metarials.[order] as 'content_content',

//Step.banner_img as 'Step_banner_img',
//Step.blog_id as 'Step_blog_id',
//Step.desciption as 'Step_desciption',
//Step.id as 'Step_id',
//Step.name as 'Step_name',
//Step.[order] as 'Step_order'

//from Blogers
//inner join contents on contents.blog_id = Blogers.id
//inner join metarials on metarials.blog_id = Blogers.id
//inner join Step on Step.blog_id = Blogers.id
//where Blogers.id = " + id;
//            DataTable table = new DataTable();
//            string sqlDataSource = _configuration.GetConnectionString("BE_DrinkContext");
//            SqlDataReader myRender;
//            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
//            {
//                myCon.Open();
//                using (SqlCommand myCommand = new SqlCommand(query, myCon))
//                {
//                    myRender = myCommand.ExecuteReader();
//                    table.Load(myRender);
//                    myRender.Close(); myCon.Close();
//                }
//            }
//            return new JsonResult(table);
//        }


        // PUT: api/Blogeres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBloger(long id, Bloger Bloger)
        {
            if (id != Bloger.id)
            {
                return BadRequest();
            }

            _context.Entry(Bloger).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogerExists(id))
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

        // POST: api/Blogeres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bloger>> PostBloger(Bloger Bloger)
        {
            _context.Blogers.Add(Bloger);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBloger", new { id = Bloger.id }, Bloger);
        }

        // DELETE: api/Blogeres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBloger(long id)
        {
            var Bloger = await _context.Blogers.FindAsync(id);
            if (Bloger == null)
            {
                return NotFound();
            }

            _context.Blogers.Remove(Bloger);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BlogerExists(long id)
        {
            return _context.Blogers.Any(e => e.id == id);
        }
    }
}
