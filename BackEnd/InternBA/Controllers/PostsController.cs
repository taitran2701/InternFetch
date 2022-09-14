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
    public class PostsController : ControllerBase
    {
        private readonly IMediator mediator;

        public PostsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts([FromQuery]PageParagram pagination)
        {
            var posts = await mediator.Send(new GetAllPostsQuery(pagination));
            var metadata = new
            {
                posts.TotalCount,
                posts.PageSize,
                posts.CurrentPage,
                posts.TotalPages,
                posts.HasNext,
                posts.HasPrevious,
            };

            HttpContext.Response.Headers.Add("Post-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(posts);
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost([FromQuery] GetPostByIdQuery query)
        {
            return Ok(await mediator.Send(query));
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Post>> PutPost(Guid id, UpdatePostCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            
            return Ok(await mediator.Send(command));
        }

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(CreatedPostCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        // DELETE: api/Posts/5
        [HttpDelete]
        public async Task<IActionResult> DeletePost([FromQuery]DeletePostByIdCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
