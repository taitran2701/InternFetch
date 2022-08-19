using InternBA.Models;

namespace InternBA.Repository
{
    public class ReactionRepository : GenericRepository<Reaction>
    {
        public ReactionRepository(InternBADBContext context) : base(context)
        {
        }
    }
}
