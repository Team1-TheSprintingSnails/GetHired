using GetHired.DomainModels;

namespace GetHired.DataModels.Repositories.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetByEmail(string email);
    }
}