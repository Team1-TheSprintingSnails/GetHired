﻿using AutoMapper;
using GetHired.DataModels.Contracts;
using GetHired.DomainModels;
using System;
using System.Linq;
using GetHired.DTO;

namespace GetHired.Services.Services
{
    public class JobOfferService
    {
        private readonly IUnitOfWork unitOfWork;

        public JobOfferService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddJobOffer(JobOfferModel jobOffer)
        {
            if (jobOffer == null)
            {
                throw new ArgumentNullException();
            }

            var regularJobOffer = Mapper.Map<JobOffer>(jobOffer);

            this.unitOfWork.JobOfferRepository.Insert(regularJobOffer);
        }

        public IQueryable<JobOffer> GetAllJobOffers()
        {
            // implementation

            var allJobOffers = this.unitOfWork.JobOfferRepository.All;
            return allJobOffers;
        }
    }
}