using AutoMapper;
using GetHired.DataModels.Contracts;
using GetHired.DomainModels;
using GetHired.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using GetHired.Services.Contracts;

namespace GetHired.Services.Services
{
    class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public bool Add(CompanyModel model)
        {
            if (model == null) return false;

            try
            {
                var company = this.mapper.Map<Company>(model);
                this.unitOfWork.CompanyRepository.Insert(company);
                this.unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteById(int companyId)
        {
            try
            {
                var company = this.unitOfWork.CompanyRepository.GetById(companyId);
                this.unitOfWork.CompanyRepository.Delete(company);
                this.unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(CompanyModel model)
        {
            if (model == null) return false;

            try
            {
                var company = this.mapper.Map<Company>(model);
                this.unitOfWork.CompanyRepository.Delete(company);
                this.unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(CompanyModel model)
        {
            if (model == null) return false;

            try
            {
                var company = this.mapper.Map<Company>(model);
                this.unitOfWork.CompanyRepository.Update(company);
                this.unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<CompanyModel> GetAll()
        {
            var companies = this.unitOfWork.CompanyRepository.All;
            return companies.Select(c => this.mapper.Map<CompanyModel>(c));
        }

        public CompanyModel GetById(int companyId)
        {
            var company = this.unitOfWork.CompanyRepository.GetById(companyId);
            return this.mapper.Map<CompanyModel>(company);
        }
    }
}