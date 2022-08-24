﻿using System;
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
    public class ReactionsController : ControllerBase
    {
        private readonly InternBADBContext _context;

        public ReactionsController(InternBADBContext context)
        {
            _context = context;
        }

        // GET: api/Reactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reaction>>> GetReactions()
        {
          if (_context.Reactions == null)
          {
              return NotFound();
          }
            return await _context.Reactions.Where(r => r.DeleteAt != null).ToListAsync();
        }

        // GET: api/Reactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reaction>> GetReaction(Guid id)
        {
          if (_context.Reactions == null)
          {
              return NotFound();
          }
            var reaction = await _context.Reactions.FindAsync(id);

            if (reaction == null)
            {
                return NotFound();
            }

            return reaction;
        }

        // PUT: api/Reactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Reaction>> PutReaction(Guid id, ReactionViewModel reaction)
        {
            if (id != reaction.ID)
            {
                return BadRequest();
            }

            var result = _context.Reactions.Find(id);
            result.ID = reaction.ID;    
            result.Expression = reaction.Expression;
            result.CommentID=reaction.CommentID;
            result.PostID = reaction.PostID;
            _context.Entry(reaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReactionExists(id))
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

        // POST: api/Reactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reaction>> PostReaction(ReactionViewModel reaction)
        {
          if (_context.Reactions == null)
          {
              return Problem("Entity set 'InternBADBContext.Reactions'  is null.");
          }
            var react = new Reaction()
            {
                ID = reaction.ID,
                UserID = reaction.UserID,
                Expression = reaction.Expression,
                CommentID = reaction.CommentID,
                PostID = reaction.PostID,
            };
            _context.Reactions.Add(react);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReaction", new { id = reaction.ID }, reaction);
        }

        // DELETE: api/Reactions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Reaction>>> DeleteReaction(Guid id)
        {
            if (_context.Reactions == null)
            {
                return NotFound();
            }
            var reaction = await _context.Reactions.FindAsync(id);
            if (reaction == null)
            {
                return NotFound();
            }
            reaction.DeleteAt = DateTime.UtcNow;
/*            _context.Reactions.Remove(reaction);
*/            await _context.SaveChangesAsync();

            return await _context.Reactions.Where(r=>r.DeleteAt != null).ToListAsync();
        }

        private bool ReactionExists(Guid id)
        {
            return (_context.Reactions?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
