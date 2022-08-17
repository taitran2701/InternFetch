namespace InternBA.Interfaces
{
    public interface IMessageRepository : IDisposable
    {
        IEnumerable<Message> GetAllMessage();
        Message GetById(int id);
        void InsertMessage(Message message);
        void UpdateMessage(Message message);
        void DeleteMessage(int id);
        void Save();
    }
}
