using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using GetHired.DataModels.Repositories.Contracts;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DataModels.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IIdentifiable<int>
    {
        private readonly DbContext context;
        private readonly DbSet<TEntity> dbSet;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            dbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            var entityToDelete = this.dbSet.Find(id);
            this.Delete(entityToDelete);
        }

        public TEntity GetById(int id)
        {
            return this.dbSet.Find(id);
        }

        public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException();
            }

            return this.dbSet.Where(filter);
        }

        public void Insert(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}