using AutoMapper;
using GetHired.DataModels.Contracts;
using GetHired.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using GetHired.DTO;
using GetHired.DTO.ViewModels;
using GetHired.Services.Contracts;

namespace GetHired.Services.Services
{
    public class JobOfferService : IJobOfferService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public JobOfferService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public bool Add(JobOfferModel model)
        {
            if (model == null) return false;

            try
            {
                var jobOffer = this.mapper.Map<JobOffer>(model);
                this.unitOfWork.JobOfferRepository.Insert(jobOffer);
                this.unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(JobOfferModel model)
        {
            if (model == null) return false;

            try
            {
                var jobOffer = this.mapper.Map<JobOffer>(model);
                this.unitOfWork.JobOfferRepository.Delete(jobOffer);
                this.unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(JobOfferModel model)
        {
            if (model == null) return false;

            try
            {
                var jobOffer = this.mapper.Map<JobOffer>(model);
                this.unitOfWork.JobOfferRepository.Update(jobOffer);
                this.unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<JobOfferModel> GetAll()
        {
            var jobOffers = this.unitOfWork.JobOfferRepository
                .GetAllOrderedByRating();

            return jobOffers.Select(j => this.mapper.Map<JobOfferModel>(j));
        }

        public IEnumerable<JobOfferModel> GetByCompanyId(int companyId)
        {
            var jobOffers = this.unitOfWork.JobOfferRepository
                .GetByCompanyId(companyId);

            return jobOffers.Select(j => this.mapper.Map<JobOfferModel>(j));
        }

        public JobOfferModel GetById(int jobOfferId)
        {
            var jobOffer = this.unitOfWork.JobOfferRepository.GetById(jobOfferId);
            return this.mapper.Map<JobOfferModel>(jobOffer);
        }

        public IEnumerable<JobOfferModel> GetByUserId(int userId)
        {
            var jobOffers = this.unitOfWork.JobOfferRepository
                .GetByUserId(userId);

            return jobOffers.Select(j => this.mapper.Map<JobOfferModel>(j));
        }

        public JobOfferWithCompanyViewModel GetByIdWithCompany(int jobOfferId)
        {
            var jobOffers = this.unitOfWork.JobOfferRepository
                .GetJobOfferWithCompany(jobOfferId);

            return this.mapper.Map<JobOfferWithCompanyViewModel>(jobOffers);
        }

        public bool DeleteById(int jobOfferId)
        {
            try
            {
                var jobOffer = this.unitOfWork.JobOfferRepository.GetById(jobOfferId);
                this.unitOfWork.JobOfferRepository.Delete(jobOffer);
                this.unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}