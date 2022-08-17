namespace InternBA.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void DeleteById(int id);
        void UpdateById(int id, User user);
        void InsertUser(User user);
        void Save();

    }
}
