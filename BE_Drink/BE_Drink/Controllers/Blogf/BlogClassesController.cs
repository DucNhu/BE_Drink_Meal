using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BE_Drink.DbContext;
using BE_Drink.Models;

namespace BE_Drink.Controllers.Blogf
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogeresController : ControllerBase
    {
        private readonly BE_DrinkContext _context;

        public BlogeresController(BE_DrinkContext context)
        {
            _context = context;
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
