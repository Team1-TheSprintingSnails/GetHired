using GetHired.DataModels.Repositories.Contracts;
using GetHired.DomainModels;

namespace GetHired.DataModels.UnitsOfWork.Contracts
{
    public interface IUnitOfWork
    {
        IAddressRepository AddressRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        IJobOfferRepository JobOfferRepository { get; }
        ITownRepository TownRepository { get; }
        IUserRepository UserRepository { get; }
        IGenericRepository<JobType> JobTypeReadonlyRepository { get; }
        IGenericRepository<JobCategory> JobCategoryReadonlyRepository { get; }

        int SaveChanges();
    }
}