using InternBA.Generic;
using InternBA.Repository;
using Microsoft.EntityFrameworkCore;

namespace InternBA.SeedWork
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
