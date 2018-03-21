using GetHired.DataModels.Contracts;
using GetHired.DataModels.Repositories;
using GetHired.DataModels.Repositories.Contracts;
using GetHired.DomainModels.Utilities;

namespace GetHired.DataModels
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IGetHiredContext context;

        private IAddressRepository addressRepository;
        private ICompanyRepository companyRepository;
        private IJobOfferRepository jobOfferRepository;
        private ITownRepository townRepository;
        private IUserRepository userRepository;
        private IReadonlyRepository<JobType> jobTypeReadonlyRepository;
        private IReadonlyRepository<JobCategory> jobCategoryReadonlyRepository;

        public UnitOfWork(IGetHiredContext context)
        {
            this.context = context;
        }

        public IAddressRepository AddressRepository
        {
            get
            {
                return this.addressRepository ?? (this.addressRepository =
                           new AddressRepository(this.context));
            }
        }

        public ICompanyRepository CompanyRepository
        {
            get
            {
                return this.companyRepository ?? (this.companyRepository =
                           new CompanyRepository(this.context));
            }
        }

        public IJobOfferRepository JobOfferRepository
        {
            get
            {
                return this.jobOfferRepository ?? (this.jobOfferRepository =
                           new JobOfferRepository(this.context));
            }
        }

        public ITownRepository TownRepository
        {
            get
            {
                return this.townRepository ?? (this.townRepository = new TownRepository(this.context));
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                return this.userRepository ?? (this.userRepository = new UserRepository(this.context));
            }
        }

        public IReadonlyRepository<JobType> JobTypeReadonlyRepository
        {
            get
            {
                return this.jobTypeReadonlyRepository ??
                       (this.jobTypeReadonlyRepository = new GenericRepository<JobType>(this.context));
            }
        }

        public IReadonlyRepository<JobCategory> JobCategoryReadonlyRepository
        {
            get
            {
                return this.jobCategoryReadonlyRepository ??
                       (this.jobCategoryReadonlyRepository = new GenericRepository<JobCategory>(this.context));
            }
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}