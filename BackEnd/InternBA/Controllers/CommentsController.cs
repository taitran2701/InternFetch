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
    public class CommentsController : ControllerBase
    {
        private readonly IMediator mediator;

        public CommentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/Comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments([FromQuery]PageParagram pagination)
        {
            var comments = await mediator.Send(new GetAllCommentsQuery(pagination));
            var metadata = new
            {
                comments.TotalCount,
                comments.PageSize,
                comments.CurrentPage,
                comments.TotalPages,
                comments.HasNext,
                comments.HasPrevious,
            };

            HttpContext.Response.Headers.Add("Comment-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(comments);
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment([FromQuery] GetCommentByIdQuery query)
        {
          
            return Ok(await mediator.Send(query));
        }

        // PUT: api/Comments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(Guid id, UpdateCommentCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }                       

            return Ok(await mediator.Send(command));
        }

        // POST: api/Comments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(CreateCommentCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment([FromQuery] DeleteCommentByIdCommand command)
        {
            return Ok(await mediator.Send(command));

        }
       

        //Get COmment with filterS
        [HttpGet]
        [Route("filter")]
        public async Task<ActionResult<Comment>> GetCommentsWithFilter([FromQuery] GetCommnetByFilterQuery query)
        {
            return Ok(await mediator.Send(query));
        }

    }
}
