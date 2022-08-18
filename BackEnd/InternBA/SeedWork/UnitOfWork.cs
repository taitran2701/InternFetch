namespace InternBA.SeedWork
{
    public class UnitOfWork : IDisposable
    {
        // todo: XuanLoi - context will update later
        private InternBADBContext context = null;
        private GenericRepository<Room> roomRepository;
        private GenericRepository<User> userRepository;
        private GenericRepository<Message> messageRepository;

        public GenericRepository<User> UserRepository => userRepository ?? new GenericRepository<User>(context);
        public GenericRepository<Room> RoomRepository => roomRepository ?? new GenericRepository<Room>(context);

        public GenericRepository<Message> MessageRepository => messageRepository ?? new GenericRepository<Message>(context);
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
