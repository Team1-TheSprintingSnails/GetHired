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
        IReadonlyRepository<JobType> JobTypeReadonlyRepository { get; }
        IReadonlyRepository<JobCategory> JobCategoryReadonlyRepository { get; }

        void Save();
    }
}