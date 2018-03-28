using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using GetHired.DataModels.Contracts;
using GetHired.DataModels.Repositories.Contracts;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DataModels.Repositories.Models
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IIdentifiable<int>
    {
        private readonly IGetHiredContext context;
        private readonly IDbSet<TEntity> dbSet;

        public GenericRepository(IGetHiredContext context)
        {
            this.context = context;
            this.dbSet = this.Context.Set<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            this.context.Entry(entity).State = EntityState.Deleted;
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
            this.context.Entry(entity).State = EntityState.Unchanged;
        }

        public TEntity GetById(int id)
        {
            return this.DbSet
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<TEntity> All
        {
            get
            {
                return this.DbSet
                    .AsNoTracking()
                    .AsEnumerable();
            }
        }

        protected IGetHiredContext Context
        {
            get { return context; }
        }

        protected IDbSet<TEntity> DbSet
        {
            get { return dbSet; }
        }

        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Where(predicate)
                .AsEnumerable();
        }

        public void Insert(TEntity entity)
        {
            this.context.Entry(entity).State = EntityState.Added;
        }

        public void Update(TEntity entity)
        {
            this.Context.Entry(entity).State = EntityState.Modified;
        }
    }
}