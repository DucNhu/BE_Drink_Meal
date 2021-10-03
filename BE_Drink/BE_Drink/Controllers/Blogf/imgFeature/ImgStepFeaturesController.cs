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
    public class ImgStepFeaturesController : ControllerBase
    {
        private readonly BE_DrinkContext _context;

        public ImgStepFeaturesController(BE_DrinkContext context)
        {
            _context = context;
        }

        // GET: api/ImgStepFeatures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImgStepFeature>>> GetImgStepFeature()
        {
            return await _context.ImgStepFeature.ToListAsync();
        }

        // GET: api/ImgStepFeatures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImgStepFeature>> GetImgStepFeature(long id)
        {
            var imgStepFeature = await _context.ImgStepFeature.FindAsync(id);

            if (imgStepFeature == null)
            {
                return NotFound();
            }

            return imgStepFeature;
        }

        // PUT: api/ImgStepFeatures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImgStepFeature(long id, ImgStepFeature imgStepFeature)
        {
            if (id != imgStepFeature.id)
            {
                return BadRequest();
            }

            _context.Entry(imgStepFeature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImgStepFeatureExists(id))
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

        // POST: api/ImgStepFeatures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ImgStepFeature>> PostImgStepFeature(ImgStepFeature imgStepFeature)
        {
            _context.ImgStepFeature.Add(imgStepFeature);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImgStepFeature", new { id = imgStepFeature.id }, imgStepFeature);
        }

        // DELETE: api/ImgStepFeatures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImgStepFeature(long id)
        {
            var imgStepFeature = await _context.ImgStepFeature.FindAsync(id);
            if (imgStepFeature == null)
            {
                return NotFound();
            }

            _context.ImgStepFeature.Remove(imgStepFeature);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImgStepFeatureExists(long id)
        {
            return _context.ImgStepFeature.Any(e => e.id == id);
        }
    }
}
