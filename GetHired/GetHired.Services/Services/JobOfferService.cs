using AutoMapper;
using GetHired.DataModels.Contracts;
using GetHired.DomainModels;
using System;
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

        public void AddJobOfferWithNewDependencies(JobOfferModel jobOfferModel, CompanyModel companyModel,
            JobTypeModel jobTypeModel = null, JobCategoryModel jobCategoryModel = null)
        {
            var jobOffer = mapper.Map<JobOfferModel, JobOffer>(jobOfferModel);
            var company = mapper.Map<CompanyModel, Company>(companyModel);

            var jobCategory = jobCategoryModel != null 
                ? mapper.Map<JobCategoryModel, JobCategory>(jobCategoryModel)
                : null;

            var jobType = jobTypeModel != null 
                ? mapper.Map<JobTypeModel, JobType>(jobTypeModel)
                : null;

            this.unitOfWork
                .JobOfferRepository
                .Insert(jobOffer);

            this.unitOfWork
                .CompanyRepository
                .Insert(company);

            jobOffer.Company = company;
            jobOffer.JobType = jobType;
            jobOffer.JobCategory = jobCategory;

            this.unitOfWork.SaveChanges();
        }
    }
}