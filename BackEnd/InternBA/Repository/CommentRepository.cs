using InternBA.Models;

namespace InternBA.Repository
{
    public class CommentRepository : GenericRepository<Comment>
    {
        public CommentRepository(InternBADBContext context) : base(context)
        {
        }
        public IEnumerable<Comment> GetPopularComments(int count)
        {
            return _context.Comments.OrderByDescending(c => c.Reaction).Take(count).ToList();
        }
    }
}
