using InternBA.Generic;

namespace InternBA.Models
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(InternBADBContext context) : base(context)
        {
        }
    }
}
