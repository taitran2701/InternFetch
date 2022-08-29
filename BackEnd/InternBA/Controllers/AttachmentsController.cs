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
    public class AttachmentsController : ControllerBase
    {
        private readonly InternBADBContext _context;

        public AttachmentsController(InternBADBContext context)
        {
            _context = context;
        }

        // GET: api/Attachments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attachment>>> GetAttachments()
        {
          if (_context.Attachments == null)
          {
              return NotFound();
          }
            return await _context.Attachments.Where(a=>a.DeleteAt == null).ToListAsync();
        }

        // GET: api/Attachments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Attachment>> GetAttachment(Guid id)
        {
          if (_context.Attachments == null)
          {
              return NotFound();
          }
            var attachment = await _context.Attachments.FindAsync(id);

            if (attachment == null)
            {
                return NotFound();
            }

            return attachment;
        }

        // PUT: api/Attachments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Attachment>> PutAttachment(Guid id, AttachmentViewModel updateAttachment)
        {
            if (id != updateAttachment.ID)
            {
                return BadRequest();
            }

            var result = _context.Attachments.Find(id);

            result.CategoryId = updateAttachment.CategoryID;
            
            _context.Entry(result).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttachmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return result   ;
        }

        // POST: api/Attachments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<List<Attachment>>> PostAttachment(AttachmentViewModel attachment)
        {
          if (_context.Attachments == null)
          {
              return Problem("Entity set 'InternBADBContext.Attachments'  is null.");
          }

            var newAttach = new Attachment()
            {
                ID = new Guid(),
                PostID = attachment.PostID,
                CategoryId = attachment.CategoryID,
            };

            _context.Attachments.Add(newAttach);

            _context.Attachments.Add(newAttach);

            await _context.SaveChangesAsync();

            await _context.Attachments.ToListAsync();

            return CreatedAtAction("GetAttachment", new { id = attachment.ID }, attachment);
        }

        // DELETE: api/Attachments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Attachment>>> DeleteAttachment(Guid id)
        {
            if (_context.Attachments == null)
            {
                return NotFound();
            }
            var attachment = await _context.Attachments.FindAsync(id);
            if (attachment == null)
            {
                return NotFound();
            }

            attachment.DeleteAt = DateTime.UtcNow;
            //_context.Attachments.Remove(attachment);

            await _context.SaveChangesAsync();

            return _context.Attachments.Where(x => x.ID == attachment.ID).ToList();
        }

        private bool AttachmentExists(Guid id)
        {
            return (_context.Attachments?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
