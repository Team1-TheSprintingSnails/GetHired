using System.Linq;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DataModels.Repositories.Contracts
{
    public interface IReadonlyRepository<out TEntity> where TEntity : class, IIdentifiable<int>
    {
        IQueryable<TEntity> All { get; }
        TEntity GetById(int id);
    }
}
