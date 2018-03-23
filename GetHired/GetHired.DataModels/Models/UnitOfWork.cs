using GetHired.DataModels.Contracts;
using GetHired.DataModels.Repositories.Contracts;
using GetHired.DataModels.Repositories.Models;
using GetHired.DomainModels;

namespace GetHired.DataModels.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IGetHiredContext context;

        private IAddressRepository addressRepository;
        private ICompanyRepository companyRepository;
        private IJobOfferRepository jobOfferRepository;
        private ITownRepository townRepository;
        private IUserRepository userRepository;
        private IGenericRepository<JobType> jobTypeRepository;
        private IGenericRepository<JobCategory> jobCategoryRepository;

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

        public IGenericRepository<JobType> JobTypeReadonlyRepository
        {
            get
            {
                return this.jobTypeRepository ??
                       (this.jobTypeRepository = new GenericRepository<JobType>(this.context));
            }
        }

        public IGenericRepository<JobCategory> JobCategoryReadonlyRepository
        {
            get
            {
                return this.jobCategoryRepository ??
                       (this.jobCategoryRepository = new GenericRepository<JobCategory>(this.context));
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}