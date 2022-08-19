using System.Linq.Expressions;

namespace InternBA.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity GetByID (int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        void Add(TEntity entity);
        void AddRange (IEnumerable<TEntity> entities);
        void Remove (TEntity entity);
        void RemoveRange (IEnumerable<TEntity> entities);
        void Update (TEntity entity);
    }
}
