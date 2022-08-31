using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternBA;
using MediatR;
using InternBA.Features.UserFeatures.Queries;
using InternBA.Features.UserFeatures.Command;
using InternBA.Infrastructure.Data;
using InternBA.Models;
using InternBA.ViewModels;
using Newtonsoft.Json;

namespace InternBA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers([FromQuery]PageParagram pagination)
        {
            var users = await mediator.Send(new GetAllUsersQuery(pagination));
            var metadata = new
            {
                users.TotalCount,
                users.PageSize,
                users.CurrentPage,
                users.TotalPages,
                users.HasNext,
                users.HasPrevious
            };

            HttpContext.Response.Headers.Add("User-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(users);
        }
        //GET: api/Users/
        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserSearch(string search)
        {
            return Ok(await mediator.Send(new GetUserSearchQuery(search)));
        }

        // GET: username and password
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<UserViewModel>> GetUserByUserName(LoginInformation login)
        {
            var user = await mediator.Send(new GetUserByUserNameQuery(login));
            return Ok(user);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser([FromQuery] GetUserByIdQuery query)
        {
            return Ok(await mediator.Send(query));
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await mediator.Send(command));
        }

        [HttpPut]
        [Route("password")]
        public async Task<IActionResult> PutUserForgotPassword(UpdateUserPasswordCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(CreateUserCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPost]
        [Route("account")]
        public async Task<ActionResult<User>> PostUserAccount(CreateUserAccountCommand command)
        {
            return Ok(await mediator.Send(command));
        }


        //DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromQuery]DeleteUserByIdCommand command)
        {
            return Ok(await mediator.Send(command));
        }


        //private bool UserExists(Guid id)
        //{
        //    return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
