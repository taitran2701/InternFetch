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
using Newtonsoft.Json;

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
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms([FromQuery] PageParagram page)
        {
            var rooms = await mediator.Send(new GetAllRoomsQuery(page));
            var metadata = new
            {
                rooms.TotalCount,
                rooms.PageSize,
                rooms.CurrentPage,
                rooms.TotalPages,
                rooms.HasNext,
                rooms.HasPrevious
            };

            HttpContext.Response.Headers.Add("Room-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(rooms);
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom([FromQuery]GetRoomByIdQuery query)
        {
            //if (_context.Rooms == null)
            //{
            //    return NotFound();
            //}
            //var room = await _context.Rooms.FindAsync(id);

            //if (room == null)
            //{
            //    return NotFound();
            //}

            //return room;
            return Ok(await mediator.Send(query));
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
            //var result = _context.Rooms.Find(id);
            //result.Id = room.Id;
            //result.User1 = room.User1;
            //result.User2 = room.User2;
            //result.UpdatedDate = DateTime.UtcNow;
            //_context.Entry(result).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!RoomExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return result;
            return Ok(await mediator.Send(command));
        }

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(CreateRoomCommand command)
        {

            //if (_context.Rooms == null)
            //{
            //    return Problem("Entity set 'InternBADBContext.Rooms'  is null.");
            //}
            //var rm = new Room()
            //{
            //    Id = room.Id,
            //    User1 = room.User1,
            //    User2 = room.User2
            //};
            //_context.Rooms.Add(rm);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetRoom", new { id = room.Id }, room);  
            return Ok(await mediator.Send(command));
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Room>>> DeleteRoom(Guid id, DeleteRoomByIdCommand command)
        {
            //if (_context.Rooms == null)
            //{
            //    return NotFound();
            //}
            //var room = await _context.Rooms.FindAsync(id);
            //if (room == null)
            //{
            //    return NotFound();
            //}
            //room.DeleteAt = DateTime.UtcNow;
            ////_context.Rooms.Remove(room);
            //await _context.SaveChangesAsync();

            //return await _context.Rooms.Where(r => r.DeleteAt != null).ToListAsync();
            return Ok(await mediator.Send(command));
        }

    }
}
