using InternBA.Generic;

namespace InternBA.Models
{
    public class UnitOfWork : IDisposable
    {
        private InternBADBContext context = new();
        private GenericRepository<Room> roomRepository;
        private GenericRepository<User> userRepository;
        private GenericRepository<Message> messageRepository;

        public GenericRepository<User> UserRepository => userRepository ?? new GenericRepository<User>(context);
        public GenericRepository<Room> RoomRepository
        {
            get
            {
                if (this.roomRepository == null)
                {
                    roomRepository = new GenericRepository<Room>(context);
                }
                return roomRepository;
            }
        }
        public GenericRepository<Message> MessageRepository
        {
            get
            {
                if (this.messageRepository == null)
                {
                    this.messageRepository = new GenericRepository<Message>(context);
                }
                return messageRepository;
            }
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public void Save()
        {
            context.SaveChanges();

        }
        private bool diposed = false;

    }
}
