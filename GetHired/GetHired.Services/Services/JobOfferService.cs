using AutoMapper;
using GetHired.DomainModels;
using GetHired.DataModels.UnitsOfWork.Contracts;
using GetHired.DTO;

namespace GetHired.Services.Services
{
    public class JobOfferService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public JobOfferService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public void UpdateJobOffer(JobOfferModel jobOfferModel)
        {
            var jobOffer = mapper.Map<JobOfferModel, JobOffer>(jobOfferModel);

            this.unitOfWork
                .JobOfferRepository
                .Update(jobOffer);

            this.unitOfWork
                .SaveChanges();
        }

        /// <summary>
        /// Adds JobOfferModel with companyModel that does not exist
        /// </summary>
        /// <param name="jobOfferModel"></param>
        /// <param name="companyModel"></param>
        public void AddWithNewDependent(JobOfferModel jobOfferModel, CompanyModel companyModel)
        {
            var jobOffer = mapper.Map<JobOfferModel, JobOffer>(jobOfferModel);
            var company = mapper.Map<CompanyModel, Company>(companyModel);

            this.unitOfWork
                .JobOfferRepository
                .Insert(jobOffer);

            this.unitOfWork
                .CompanyRepository
                .Insert(company);

            jobOffer.Company = company;

            this.unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Adds JobOfferModel with companyModel that exists
        /// </summary>
        /// <param name="jobOfferModel"></param>
        /// <param name="companyModel"></param>
        public void AddWithExistingDependent(JobOfferModel jobOfferModel, CompanyModel companyModel)
        {
            var jobOffer = mapper.Map<JobOfferModel, JobOffer>(jobOfferModel);
            var company = mapper.Map<CompanyModel, Company>(companyModel);

            this.unitOfWork
                .JobOfferRepository
                .Insert(jobOffer);

            this.unitOfWork
                .CompanyRepository
                .Attach(company);

            jobOffer.Company = company;

            this.unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Updates JobOfferModel when jobCategoryModel and jobTypeModel exist
        /// </summary>
        /// <param name="jobOfferModel"></param>
        /// <param name="jobCategoryModel"></param>
        /// <param name="jobTypeModel"></param>
        public void UpdateDependecies(JobOfferModel jobOfferModel, 
            JobCategoryModel jobCategoryModel = null, JobTypeModel jobTypeModel = null)
        {
            var jobOffer = mapper.Map<JobOfferModel, JobOffer>(jobOfferModel);

            var jobCategory = jobCategoryModel != null
                ? mapper.Map<JobCategoryModel, JobCategory>(jobCategoryModel)
                : null;

            var jobType = jobTypeModel != null
                ? mapper.Map<JobTypeModel, JobType>(jobTypeModel)
                : null;

            this.unitOfWork
                .JobOfferRepository
                .Insert(jobOffer);
            
            jobOffer.JobType = jobType;
            jobOffer.JobCategory = jobCategory;

            this.unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Deletes job offer from db
        /// </summary>
        /// <param name="jobOfferModel"></param>
        public void DeleteJobOffer(JobOfferModel jobOfferModel)
        {
            var jobOffer = mapper.Map<JobOfferModel, JobOffer>(jobOfferModel);

            this.unitOfWork
                .JobOfferRepository
                .Delete(jobOffer);

            this.unitOfWork.SaveChanges();
        }
    }
}