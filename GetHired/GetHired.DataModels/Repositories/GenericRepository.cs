﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using GetHired.DataModels.Contracts;
using GetHired.DataModels.Repositories.Contracts;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DataModels.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
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
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            if (this.Context.Entry(entity).State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            this.DbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public TEntity GetById(int id)
        {
            return this.DbSet.AsNoTracking().FirstOrDefault(x => x.Id == id);
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

        public IEnumerable<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return this.DbSet.AsNoTracking()
                .Where(predicate)
                .AsEnumerable();
        }

        public void Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            this.DbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            var entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }
    }
}