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
            return await _context.Attachments.ToListAsync();
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
        public async Task<ActionResult<Attachment>> PutAttachment(Guid id, AttachmentViewModel attachment)
        {
            if (id != attachment.ID)
            {
                return BadRequest();
            }

            var result = _context.Attachments.Find(id);
            result.ID = attachment.ID;
            result.PostID = attachment.PostID;
            result.CategoryID = attachment.CategoryID;


            _context.Entry(attachment).State = EntityState.Modified;

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
        public async Task<ActionResult<Attachment>> PostAttachment(AttachmentViewModel attachment)
        {
          if (_context.Attachments == null)
          {
              return Problem("Entity set 'InternBADBContext.Attachments'  is null.");
          }

            var at = new Attachment()
            {
                ID = attachment.ID,
                PostID = attachment.PostID,
                CategoryID = attachment.CategoryID,
            };
            _context.Attachments.Add(at);
            await _context.SaveChangesAsync();

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

            _context.Attachments.Remove(attachment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttachmentExists(Guid id)
        {
            return (_context.Attachments?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
