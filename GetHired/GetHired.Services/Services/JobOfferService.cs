using AutoMapper;
using GetHired.DataModels.Contracts;
using GetHired.DomainModels;
using GetHired.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}