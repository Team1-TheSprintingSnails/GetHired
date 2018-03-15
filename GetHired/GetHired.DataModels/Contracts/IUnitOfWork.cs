using GetHired.DataModels.Repositories.Contracts;
using GetHired.DomainModels;

namespace GetHired.DataModels.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<Address> AddressRepository { get; }
        IRepository<Company> CompanyRepository { get; }
        IRepository<ContactInfo> ContactsRepository { get; }
        IRepository<JobOffer> JobOfferRepository { get; }
        IRepository<Town> TownRepository { get; }
        IRepository<User> UserRepository { get; }

        void Save();
    }
}