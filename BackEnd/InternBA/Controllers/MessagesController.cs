using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternBA;
using InternBA.Infrastructure.Data;
using InternBA.ViewModels;

namespace InternBA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly InternBADBContext _context;

        public MessagesController(InternBADBContext context)
        {
            _context = context;
        }

        // GET: api/Messages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
        {
            if (_context.Messages == null)
            {
                return NotFound();
            }
            return await _context.Messages.Where(m => m.DeleteAt == null).ToListAsync();
        }

        // GET: api/Messages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessage(Guid id)
        {
            if (_context.Messages == null)
            {
                return NotFound();
            }
            var message = await _context.Messages.FindAsync(id);

            if (message == null)
            {
                return NotFound();
            }

            return message;
        }

        // PUT: api/Messages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Message>> PutMessage(Guid id, MessageViewModel message)
        {
            if (id != message.ID)
            {
                return BadRequest();
            }
            var result = await _context.Messages.FindAsync(id);
            result.Content = message.Content;
            result.UpdatedDate = DateTime.UtcNow;
            _context.Entry(result).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageExists(id))
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

        // POST: api/Messages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Message>> PostMessage(MessageViewModel message)
        {
            if (_context.Messages == null)
            {
                return Problem("Entity set 'InternBADBContext.Messages'  is null.");
            }
            var ms = new Message()
            {
                ID = message.ID,
                UserId = message.UserId,
                Content = message.Content,
                CreatedDate = DateTime.UtcNow,
                RoomId = message.RoomId
            };
            _context.Messages.Add(ms);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessage", new { id = message.ID }, message);
        }

        // DELETE: api/Messages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Message>>> DeleteMessage(Guid id)
        {
            if (_context.Messages == null)
            {
                return NotFound();
            }
            var message = await _context.Messages.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }
            message.DeleteAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return await _context.Messages.Where(m => m.DeleteAt != null).ToListAsync();
        }

        private bool MessageExists(Guid id)
        {
            return (_context.Messages?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
