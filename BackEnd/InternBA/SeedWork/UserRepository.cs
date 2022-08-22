namespace InternBA.SeedWork
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(InternBADBContext context) : base(context)
        {
        }
    }
}
