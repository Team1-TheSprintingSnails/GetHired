using AutoMapper;
using GetHired.DataModels.Contracts;
using GetHired.DomainModels;
using GetHired.DTO;
using System;

namespace GetHired.Services.Services
{
    class CompanyService
    {
        private IUnitOfWork unitOfWork;

        public CompanyService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddCompany(CompanyModel company)
        {
            if (company == null)
            {
                throw new ArgumentNullException();
            }

            var regularCompany = Mapper.Map<Company>(company);
            this.unitOfWork.CompanyRepository.Insert(regularCompany);
        }
    }
}