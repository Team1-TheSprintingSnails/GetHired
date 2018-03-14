using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DataModels.Repositories.Contracts
{
    public interface IRepository<TEntity> where TEntity : class, IIdentifiable<int>
    {
        IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> filter);
        TEntity GetById(int id);
        void Insert(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
        void Update(TEntity entity);
    }
}