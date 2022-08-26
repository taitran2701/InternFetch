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
            var query = new GetAllMessagesQuery();
            return Ok(await mediator.Send(query));
        }

        // GET: api/Messages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessage(Guid id)
        {
            var query = new GetMessageByIdQuery(id);
            return Ok(await mediator.Send(query));
        }

        // PUT: api/Messages/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Message>> PutMessage(Guid id, UpdateMessageCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        // POST: api/Messages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Message>> PostMessage(CreateMessageCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        // DELETE: api/Messages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Message>>> DeleteMessage(Guid id)
        {
            var command = new DeleteMessageByIdCommand(id);
            return Ok(await mediator.Send(command));
        }
    }
}
