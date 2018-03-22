using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using GetHired.DataModels.Contracts;
using GetHired.DataModels.Repositories.Contracts;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DataModels.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IIdentifiable<int>
    {
        public GenericRepository(IGetHiredContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<TEntity>();
        }


        protected IGetHiredContext Context { get; }

        protected IDbSet<TEntity> DbSet { get; }

        public IEnumerable<TEntity> All
        {
            get
            {
                return this.DbSet
                    .AsNoTracking();
            }
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            this.Context.Entry(entity).State = EntityState.Deleted;
        }

        public void Delete(int id)
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public void Attach(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            this.Context.Entry(entity).State = EntityState.Unchanged;
        }

        public TEntity GetById(int id)
        {
            return this.DbSet
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }


        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Where(predicate);
        }

        public void Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            this.Context.Entry(entity).State = EntityState.Added;
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            this.Context.Entry(entity).State = EntityState.Modified;
        }
    }
}