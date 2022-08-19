using InternBA.Models;

namespace InternBA.Repository
{
    public class AttachmentRepository : GenericRepository<Attachment>
    {
        public AttachmentRepository(InternBADBContext context) : base(context)
        {
        }
    }
}
