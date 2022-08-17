using InternBA.Generic;
using InternBA.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternBA.Models
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository, IDisposable
    {
        private InternBADBContext _context;
        private bool disposed = false;

        public RoomRepository(InternBADBContext context) : base(context)
        {
        }

        //public RoomRepository(InternBADBContext context)
        //{
        //    _context = context;
        //}

        //public void DeleteRoom(int id)
        //{
        //    Room room = _context.Rooms.Find(id);
        //    _context.Remove(room);
        //}

        //public void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            _context.Dispose();
        //        }
        //    }
        //    this.disposed = true;
        //}

        //public Room GetById(int id)
        //{
        //    return _context.Rooms.Find(id);
        //}

        //public IEnumerable<Room> GetAllRooms()
        //{
        //    return _context.Rooms.ToList();
        //}

        //public void InsertRoom(Room room)
        //{
        //    _context.Rooms.Add(room);
        //}


        //public void UpdateRoom(Room room)
        //{
        //    _context.Entry(room).State = EntityState.Modified;
        //}
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
