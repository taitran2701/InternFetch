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
using MediatR;
using InternBA.Features.MessageFeatures.Query;
using InternBA.Features.MessageFeatures.Command;

namespace InternBA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly InternBADBContext _context;
        private readonly IMediator mediator;
        public MessagesController(InternBADBContext context,IMediator mediator)
        {
            _context = context;
            this.mediator = mediator;
        }

        // GET: api/Messages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
        {
            return Ok(await mediator.Send(new GetAllMessagesQuery()));
        }

        // GET: api/Messages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessage()
        {
            return Ok(await mediator.Send(new GetMessageByIdQuery()));
        }

        // PUT: api/Messages/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Message>> PutMessage(Guid id, UpdateMessageCommand command)
        {
            if (id != command.ID)
            {
                return BadRequest();
            }
            return Ok(await mediator.Send(command));
        }

        // POST: api/Messages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Message>> PostMessage(CreateMessageCommand command)
        {
            //if (_context.Messages == null)
            //{
            //    return Problem("Entity set 'InternBADBContext.Messages'  is null.");
            //}
            //var ms = new Message()
            //{
            //    ID = command.ID,
            //    UserId = command.UserId,
            //    Content = command.Content,
            //    CreatedDate = DateTime.UtcNow,
            //    RoomId = command.RoomId
            //};
            //_context.Messages.Add(ms);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetMessage", new { id = command.ID }, command);
            return Ok(await mediator.Send(command));
        }

        // DELETE: api/Messages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Message>>> DeleteMessage(DeleteMessageByIdCommand command)
        {
            //if (id == )
            //{
            //    return NotFound();
            //}
            //var command = await _context.Messages.FindAsync(id);
            //if (command == null)
            //{
            //    return NotFound();
            //}
            //command.DeleteAt = DateTime.UtcNow;
            //await _context.SaveChangesAsync();

            //return await _context.Messages.Where(m => m.DeleteAt != null).ToListAsync();
            return Ok(await mediator.Send(command));
        }
    }
}
