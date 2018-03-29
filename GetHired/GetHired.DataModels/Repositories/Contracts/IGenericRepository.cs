using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DataModels.Repositories.Contracts
{
    public interface IGenericRepository<TEntity> : IReadonlyRepository<TEntity>, IWriteonlyRepository<TEntity>
        where TEntity : class, IIdentifiable<int>
    {
        IEnumerable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate);
    }
}