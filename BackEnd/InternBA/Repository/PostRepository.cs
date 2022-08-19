using InternBA.Interface;
using InternBA.Models;

namespace InternBA.Repository
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(InternBADBContext context) : base(context) { }

        public IEnumerable<Post> GetPopularPost(int count)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPopularPosts (int count)
        {
            return _context.Posts.OrderByDescending(p => p.Reaction).Take(count);
        }
    }
}
