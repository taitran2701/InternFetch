using InternBA.Infrastructure.Data;

namespace InternBA.Repository
{
    public class MessageRepository : GenericRepository<Message>
    {
        public MessageRepository(InternBADBContext context) : base(context)
        {
        }
    }
}
