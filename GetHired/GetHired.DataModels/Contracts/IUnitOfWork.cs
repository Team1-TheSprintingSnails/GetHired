using GetHired.DataModels.Repositories.Contracts;
using GetHired.DomainModels;
using GetHired.DomainModels.Utilities;

namespace GetHired.DataModels.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<Address> AddressRepository { get; }
        IRepository<Company> CompanyRepository { get; }
        IRepository<JobOffer> JobOfferRepository { get; }
        IRepository<Town> TownRepository { get; }
        IRepository<User> UserRepository { get; }
        IReadonlyRepository<JobType> JobTypeReadonlyRepository { get; }
        IReadonlyRepository<JobCategory> JobCategoryReadonlyRepository { get; }

        void Save();
    }
}