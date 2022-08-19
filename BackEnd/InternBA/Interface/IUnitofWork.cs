namespace InternBA.Interface
{
    public interface IUnitofWork : IDisposable
    {
        IPostRepository PostRepository { get; }
    }
}
