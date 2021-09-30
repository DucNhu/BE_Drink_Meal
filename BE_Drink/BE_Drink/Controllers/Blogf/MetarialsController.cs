using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BE_Drink.DbContext;
using BE_Drink.Models.BlogF;

namespace BE_Drink.Controllers.Blogf
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetarialsController : ControllerBase
    {
        private readonly BE_DrinkContext _context;

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
        [HttpGet("{id}")]
        public async Task<ActionResult<Metarial>> GetMetarial(long id)
        {
            var metarial = await _context.metarials.FindAsync(id);

            if (metarial == null)
            {
                return NotFound();
            }

            return metarial;
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
