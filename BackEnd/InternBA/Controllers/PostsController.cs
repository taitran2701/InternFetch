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
            return await _context.Posts.Where(r => r.DeleteAt == null).ToListAsync();
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
        public async Task<ActionResult<Post>> PutPost(Guid id, PutViewModel updatePost)
        {
            if (id != updatePost.ID)
            {
                return BadRequest();
            }
            var result = _context.Posts.Find(id);
            result.Content = updatePost.Content;
            //result.UserID = post.UserId;
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
        public async Task<ActionResult<List<Post>>> PostPost(PostViewModel post)
        {
            if (_context.Posts == null)
            {
                return Problem("Entity set 'InternBADBContext.Posts'  is null.");
            }
            var newPost = new Post()
            {
                ID = new Guid(),
                UserID = post.UserId,
                Content = post.Content,
                CreatedDate = DateTime.UtcNow,
            };

            _context.Posts.Add(newPost);

            await _context.SaveChangesAsync();

            await _context.Posts.ToListAsync();

            return CreatedAtAction("GetPost", new { id = newPost.ID }, post);
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

            //_context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return await _context.Posts.Where(p => p.DeleteAt != null).ToListAsync();
        }

        private bool PostExists(Guid id)
        {
            return (_context.Posts?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
