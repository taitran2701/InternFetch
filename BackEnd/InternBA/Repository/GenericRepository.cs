using InternBA.Infrastructure.Data;
using InternBA.Interfaces;
using InternBA.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InternBA.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal InternBADBContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(InternBADBContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedEnumerable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);

            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(object id)
        {
            TEntity entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }
    }
}
