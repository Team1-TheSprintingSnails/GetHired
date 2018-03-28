using GetHired.DataModels.Contracts;
using GetHired.DataModels.Repositories.Contracts;
using GetHired.DataModels.Repositories.Models;

namespace GetHired.DataModels.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IGetHiredContext context;

        private IAddressRepository addressRepository;
        private ICompanyRepository companyRepository;
        private IJobOfferRepository jobOfferRepository;
        private ICityRepository cityRepository;
        private IUserRepository userRepository;

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

        public ICityRepository CityRepository
        {
            get
            {
                return this.cityRepository ?? (this.cityRepository = new CityRepository(this.context));
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                return this.userRepository ?? (this.userRepository = new UserRepository(this.context));
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}