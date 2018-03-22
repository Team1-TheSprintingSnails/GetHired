using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DataModels.Repositories.Contracts
{
    public interface IWriteonlyRepository<in TEntity> where TEntity : class, IIdentifiable<int>
    {
        void Insert(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
        void Attach(TEntity entity);
        void Update(TEntity entity);
    }
}
