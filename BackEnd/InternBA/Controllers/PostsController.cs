using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternBA;
using InternBA.Models;
using InternBA.Infrastructure.Data;
using InternBA.ViewModels;

namespace InternBA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly InternBADBContext _context;

        public PostsController(InternBADBContext context)
        {
            _context = context;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetPosts()
        {
            if (_context.Posts == null)
            {
                return NotFound();
            }
            return Ok(await _context.Posts.ToListAsync());
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(Guid id)
        {
          if (_context.Posts == null)
          {
              return NotFound();
          }
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Post>> PutPost(Guid id, PostViewModel post)
        {
            if (id != post.ID)
            {
                return BadRequest();
            }
            var result = _context.Posts.Find(id);
            result.ID = post.ID;
            result.Content = post.Content;
            result.Reaction = post.Reaction;
            result.CommentID = post.CommentID;
            result.AttachmentID = post.AttachmentID;
            result.UpdatedDate = DateTime.UtcNow;
            _context.Entry(result).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
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

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<List<Post>>> AddPost(PostViewModel post)
        {
            if (_context.Posts == null)
            {
                return Problem("Entity set 'InternBADBContext.Posts'  is null.");
            }
            var pst = new Post()
            {
                ID = post.ID,
                Content = post.Content,
                Reaction = post.Reaction,
                CommentID = post.CommentID,
                AttachmentID = post.AttachmentID,
            };
            _context.Posts.Add(pst);
            await _context.SaveChangesAsync();

            await _context.Posts.ToListAsync();

            return CreatedAtAction("GetPost", new { id = post.ID }, post);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Post>>> DeletePost(Guid id)
        {
            if (_context.Posts == null)
            {
                return NotFound();
            }
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            post.DeleteAt = DateTime.UtcNow;

/*            _context.Posts.Remove(post);
*/            await _context.SaveChangesAsync();

            return await _context.Posts.Where(p=>p.DeleteAt != null).ToListAsync();
        }

        private bool PostExists(Guid id)
        {
            return (_context.Posts?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
