using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BE_Drink.DbContext;
using BE_Drink.Models.Blog;

namespace BE_Drink.Controllers.Blogf.imgFeature
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImgContentFeaturesController : ControllerBase
    {
        private readonly BE_DrinkContext _context;

        public ImgContentFeaturesController(BE_DrinkContext context)
        {
            _context = context;
        }

        // GET: api/ImgContentFeatures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImgContentFeature>>> GetImgContentFeature()
        {
            return await _context.ImgContentFeature.ToListAsync();
        }

        // GET: api/ImgContentFeatures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImgContentFeature>> GetImgContentFeature(long id)
        {
            var imgContentFeature = await _context.ImgContentFeature.FindAsync(id);

            if (imgContentFeature == null)
            {
                return NotFound();
            }

            return imgContentFeature;
        }

        // PUT: api/ImgContentFeatures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImgContentFeature(long id, ImgContentFeature imgContentFeature)
        {
            if (id != imgContentFeature.id)
            {
                return BadRequest();
            }

            _context.Entry(imgContentFeature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImgContentFeatureExists(id))
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

        // POST: api/ImgContentFeatures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ImgContentFeature>> PostImgContentFeature(ImgContentFeature imgContentFeature)
        {
            _context.ImgContentFeature.Add(imgContentFeature);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImgContentFeature", new { id = imgContentFeature.id }, imgContentFeature);
        }

        // DELETE: api/ImgContentFeatures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImgContentFeature(long id)
        {
            var imgContentFeature = await _context.ImgContentFeature.FindAsync(id);
            if (imgContentFeature == null)
            {
                return NotFound();
            }

            _context.ImgContentFeature.Remove(imgContentFeature);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImgContentFeatureExists(long id)
        {
            return _context.ImgContentFeature.Any(e => e.id == id);
        }
    }
}
