using InternBA.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InternBA.Generic
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal InternBADBContext context;
        internal DbSet<TEntity> dbSet;
        public GenericRepository(InternBADBContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,IOrderedEnumerable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split(new char[] {',' }, StringSplitOptions.RemoveEmptyEntries))
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
        public virtual TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }
        public virtual void Delete(object id)
        {
            TEntity entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }
        public virtual void Delete(TEntity entity)
        {
            if(context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }
        public virtual void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
