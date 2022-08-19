using InternBA.Models;
using InternBA.Repository;

namespace InternBA.Interface
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        IEnumerable<Post> GetPopularPost(int count);
    }
}
