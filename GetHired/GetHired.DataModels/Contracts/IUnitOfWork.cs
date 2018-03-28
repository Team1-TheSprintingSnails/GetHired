using GetHired.DataModels.Repositories.Contracts;
using GetHired.DomainModels;

namespace GetHired.DataModels.Contracts
{
    public interface IUnitOfWork
    {
        IAddressRepository AddressRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        IJobOfferRepository JobOfferRepository { get; }
        IReadonlyRepository<City> CityRepository { get; }
        IUserRepository UserRepository { get; }

        int SaveChanges();
    }
}