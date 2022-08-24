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

namespace InternBA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly InternBADBContext _context;

        public RoomsController(InternBADBContext context)
        {
            _context = context;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            if (_context.Rooms == null)
            {
                return NotFound();
            }
            return await _context.Rooms.Where(r => r.DeleteAt != null).ToListAsync();
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(Guid id)
        {
            if (_context.Rooms == null)
            {
                return NotFound();
            }
            var room = await _context.Rooms.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Room>> PutRoom(Guid id, RoomViewModel room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }
            var result = _context.Rooms.Find(id);
            result.Id = room.Id;
            result.User1 = room.User1;
            result.User2 = room.User2;
            result.UpdatedDate = DateTime.UtcNow;
            _context.Entry(result).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return result;
        }

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(RoomViewModel room)
        {
            
            if (_context.Rooms == null)
            {
                return Problem("Entity set 'InternBADBContext.Rooms'  is null.");
            }
            var rm = new Room()
            {
                Id = room.Id,
                User1 = room.User1,
                User2 = room.User2
            };
            _context.Rooms.Add(rm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoom", new { id = room.Id }, room);  
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Room>>> DeleteRoom(Guid id)
        {
            if (_context.Rooms == null)
            {
                return NotFound();
            }
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            room.DeleteAt = DateTime.UtcNow;
            //_context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            return await _context.Rooms.Where(r => r.DeleteAt != null).ToListAsync();
        }

        private bool RoomExists(Guid id)
        {
            return (_context.Rooms?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
