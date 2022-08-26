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
using InternBA.Features.RoomFeatures.Query;
using InternBA.Features.RoomFeatures.Command;

namespace InternBA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly InternBADBContext _context;
        private readonly IMediator mediator; 

        public RoomsController(InternBADBContext context, IMediator mediator)
        {
            _context = context;
            this.mediator = mediator;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            return Ok(await mediator.Send(new GetAllRoomsQuery()));
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(Guid id)
        {
            return Ok(await mediator.Send(new GetRoomByIdQuery()));
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Room>> PutRoom(Guid id, UpdateRoomCommand command)
        {
            if (id != command.ID)
            {
                return BadRequest();
            }
            return Ok(await mediator.Send(command));
        }

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(CreateRoomCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Room>>> DeleteRoom(Guid id, DeleteRoomByIdCommand command)
        {
            return Ok(await mediator.Send(command));
        }

    }
}
