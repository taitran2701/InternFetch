using InternBA.Generic;
using InternBA.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternBA.Models
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        private InternBADBContext _context;
        private bool disposed = false;

        public RoomRepository(InternBADBContext context) : base(context)
        {
        }

        
    }
}
