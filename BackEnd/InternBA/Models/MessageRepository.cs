using InternBA.Generic;

namespace InternBA.Models
{
    public class MessageRepository : GenericRepository<Message>
    {
        public MessageRepository(InternBADBContext context) : base(context)
        {
        }
    }
}
