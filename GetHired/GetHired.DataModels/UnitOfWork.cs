using GetHired.DataModels.Contracts;
using GetHired.DataModels.Repositories;
using GetHired.DataModels.Repositories.Contracts;
using GetHired.DomainModels;
using GetHired.DomainModels.Utilities;

namespace GetHired.DataModels
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IGetHiredContext context;

        private IRepository<Address> addressRepository;
        private IRepository<Company> companyRepository;
        private IRepository<JobOffer> jobOfferRepository;
        private IRepository<Town> townRepository;
        private IRepository<User> userRepository;
        private IRepository<ContactInfo> contactInfoRepository;
        private IReadonlyRepository<JobType> jobTypeReadonlyRepository;
        private IReadonlyRepository<JobCategory> jobCategoryReadonlyRepository;

        public UnitOfWork(IGetHiredContext context)
        {
            this.context = context;
        }

        public IRepository<Address> AddressRepository
        {
            get
            {
                return this.addressRepository ?? (this.addressRepository =
                           new GenericRepository<Address>(this.context));
            }
        }

        public IRepository<Company> CompanyRepository
        {
            get
            {
                return this.companyRepository ?? (this.companyRepository =
                           new GenericRepository<Company>(this.context));
            }
        }

        public IRepository<JobOffer> JobOfferRepository
        {
            get
            {
                return this.jobOfferRepository ?? (this.jobOfferRepository =
                           new GenericRepository<JobOffer>(this.context));
            }
        }

        public IRepository<Town> TownRepository
        {
            get
            {
                return this.townRepository ?? (this.townRepository = new GenericRepository<Town>(this.context));
            }
        }

        public IRepository<User> UserRepository
        {
            get
            {
                return this.userRepository ?? (this.userRepository = new GenericRepository<User>(this.context));
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

        public IRepository<ContactInfo> ContactInfoRepository
        {
            get
            {
                return this.contactInfoRepository ?? (this.contactInfoRepository =
                           new GenericRepository<ContactInfo>(this.context));
            }
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}