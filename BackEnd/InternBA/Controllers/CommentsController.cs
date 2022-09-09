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
    public class CommentsController : ControllerBase
    {
        private readonly InternBADBContext _context;

        public CommentsController(InternBADBContext context)
        {
            _context = context;
        }

        // GET: api/Comments
        [HttpGet]
        public async Task<ActionResult<List<Comment>>> GetComments()
        {
            if (_context.Comments == null)
            {
                return NotFound();
            }
            return await _context.Comments.Where(c => c.DeleteAt == null).ToListAsync();
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(Guid id)
        {
            if (_context.Comments == null)
            {
                return NotFound();
            }
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        // PUT: api/Comments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Comment>> PutComment(Guid id, CommentViewModel updateComment)
        {
            if (id != updateComment.ID)
            {
                return BadRequest();
            }

            var result = _context.Comments.Find(id);
            result.Content = updateComment.Content;
            result.ID = updateComment.ID;
            result.UpdatedDate = DateTime.UtcNow;
            _context.Entry(result).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
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

        // POST: api/Comments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(CommentViewModel comment)
        {
            if (_context.Comments == null)
            {
                return Problem("Entity set 'InternBADBContext.Comments'  is null.");
            }
            var newComment = new Comment()
            {
                UserID = comment.UserID,
                Content = comment.Content,
                PostID = comment.PostID,
                CreatedDate = DateTime.UtcNow,
            };
            _context.Comments.Add(newComment);
            await _context.SaveChangesAsync();

            await _context.Comments.ToListAsync();

            return CreatedAtAction("GetComment", new { id = newComment.ID }, comment);
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Comment>>> DeleteComment(Guid id)
        {
            if (_context.Comments == null)
            {
                return NotFound();
            }
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            comment.DeleteAt = DateTime.UtcNow;
            /*            _context.Comments.Remove(comment);
            */
            await _context.SaveChangesAsync();

            return await _context.Comments.Where(r => r.DeleteAt != null).ToListAsync();

        }

        private bool CommentExists(Guid id)
        {
            return (_context.Comments?.Any(e => e.ID == id)).GetValueOrDefault();
        }

        //Get COmment with filterS
        [HttpGet]
        [Route("filter")]
        public async Task<ActionResult<List<Comment>>> GetCommentsWithFilter(Guid postID)
        {
            if (_context.Comments == null)
            {
                return NotFound();
            }
            return await _context.Comments.Where(c=> c.PostID==postID && c.DeleteAt == null).OrderBy(c=>c.CreatedDate).ToListAsync();
        }

    }
}
