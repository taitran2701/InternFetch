using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternBA.Infrastructure.Data;
using InternBA.Models;
using InternBA.ViewModels;

namespace InternBA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly InternBADBContext _context;

        public CategoriesController(InternBADBContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
          if (_context.Categories == null)
          {
              return NotFound();
          }
            return await _context.Categories.Where(c => c.DeleteAt == null).ToListAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(Guid id)
        {
          if (_context.Categories == null)
          {
              return NotFound();
          }
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> PutCategory(Guid id, CateViewModel category)
        {
            if (id != category.ID)
            {
                return BadRequest();
            }

            var result = _context.Categories.Find(id);
            
            result.ID = category.ID;
            result.Images = category.Image;
            result.Video = category.Videos;
            result.UpdatedDate = DateTime.UtcNow;
            
            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return result;
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(CateViewModel category)
        {
          if (_context.Categories == null)
          {
              return Problem("Entity set 'InternBADBContext.Categories'  is null.");
          }
            var cate = new Category()
            {
                ID = category.ID,
                Images = category.Image,
                Video = category.Videos,
            };
            _context.Categories.Add(cate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.ID }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Category>>> DeleteCategory(Guid id)
        {
            if (_context.Categories == null)
            {
                return NotFound();
            }
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            category.DeleteAt = DateTime.UtcNow;
/*            _context.Categories.Remove(category);
*/            await _context.SaveChangesAsync();

            return await _context.Categories.Where(c => c.DeleteAt != null).ToListAsync();
        }

        private bool CategoryExists(Guid id)
        {
            return (_context.Categories?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
