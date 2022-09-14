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
using Newtonsoft.Json;
using InternBA.Features.UserFeatures.Queries;
using InternBA.Features.UserFeatures.Command;

namespace InternBA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactionsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ReactionsController(IMediator mediator)
        {
            this.mediator= mediator;
        }

        // GET: api/Reactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reaction>>> GetReactions([FromQuery]PageParagram pagination)
        {
            var reactions = await mediator.Send(new GetAllReactionsQuery(pagination));
            var metadata = new
            {
                reactions.TotalCount,
                reactions.PageSize,
                reactions.CurrentPage,
                reactions.TotalPages,
                reactions.HasNext,
                reactions.HasPrevious,
            };
            HttpContext.Response.Headers.Add("Reaction-Pagination",JsonConvert.SerializeObject(metadata));
            return Ok(reactions);
        }

        // GET: api/Reactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reaction>> GetReaction([FromQuery] GetReactionByIdQuery query)
        {
            return Ok(await mediator.Send(query));
        }

        // PUT: api/Reactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReaction(Guid id, UpdateReactionCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return Ok(await mediator.Send(command)) ;
        }

        // POST: api/Reactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reaction>> PostReaction(CreateReactionCommand command)
        {
            return Ok (await mediator.Send(command));
        }

        // DELETE: api/Reactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReaction([FromQuery] DeleteReactionByIdCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
