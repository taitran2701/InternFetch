using InternBA.Generic;

namespace InternBA.SeedWork
{
    public class MessageRepository : GenericRepository<Message>
    {
        public MessageRepository(InternBADBContext context) : base(context)
        {
        }
    }
}
