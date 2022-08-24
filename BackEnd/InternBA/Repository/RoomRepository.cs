using InternBA.Infrastructure.Data;
using InternBA.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace InternBA.Repository
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
