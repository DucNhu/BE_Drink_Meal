using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BE_Drink.DbContext;
using BE_Drink.Models.Product;

namespace BE_Drink.Controllers.product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImgProductFeaturesController : ControllerBase
    {
        private readonly BE_DrinkContext _context;

        public ImgProductFeaturesController(BE_DrinkContext context)
        {
            _context = context;
        }

        // GET: api/ImgProductFeatures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImgProductFeature>>> GetImgProductFeature()
        {
            return await _context.ImgProductFeature.ToListAsync();
        }

        // GET: api/ImgProductFeatures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImgProductFeature>> GetImgProductFeature(long id)
        {
            var imgProductFeature = await _context.ImgProductFeature.FindAsync(id);

            if (imgProductFeature == null)
            {
                return NotFound();
            }

            return imgProductFeature;
        }

        // PUT: api/ImgProductFeatures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImgProductFeature(long id, ImgProductFeature imgProductFeature)
        {
            if (id != imgProductFeature.id)
            {
                return BadRequest();
            }

            _context.Entry(imgProductFeature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImgProductFeatureExists(id))
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

        // POST: api/ImgProductFeatures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ImgProductFeature>> PostImgProductFeature(ImgProductFeature imgProductFeature)
        {
            _context.ImgProductFeature.Add(imgProductFeature);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImgProductFeature", new { id = imgProductFeature.id }, imgProductFeature);
        }

        // DELETE: api/ImgProductFeatures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImgProductFeature(long id)
        {
            var imgProductFeature = await _context.ImgProductFeature.FindAsync(id);
            if (imgProductFeature == null)
            {
                return NotFound();
            }

            _context.ImgProductFeature.Remove(imgProductFeature);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImgProductFeatureExists(long id)
        {
            return _context.ImgProductFeature.Any(e => e.id == id);
        }
    }
}
