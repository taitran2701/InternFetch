using InternBA.Infrastructure.Data;

namespace InternBA.Repository
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(InternBADBContext context) : base(context)
        {
        }
    }
}
