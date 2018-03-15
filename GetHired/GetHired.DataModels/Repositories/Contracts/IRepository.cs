using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DataModels.Repositories.Contracts
{
    public interface IRepository<TEntity> : IReadonlyRepository<TEntity>, IWriteonlyRepository<TEntity> 
        where TEntity : class, IIdentifiable<int>
    {
    }
}