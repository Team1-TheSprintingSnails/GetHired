using System.Collections.Generic;
using System.Linq;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DataModels.Repositories.Contracts
{
    public interface IReadonlyRepository<out TEntity> where TEntity : class, IIdentifiable<int>
    {
        IEnumerable<TEntity> All { get; }
        TEntity GetById(int id);
    }
}
