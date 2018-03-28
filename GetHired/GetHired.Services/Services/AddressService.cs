using AutoMapper;
using GetHired.DataModels.Contracts;
using GetHired.DomainModels;
using GetHired.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GetHired.Services.Services
{
    public class AddressService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AddressService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public AddressWithCityDetailsModel GetById(int id)
        {
            var address = this.unitOfWork
                .AddressRepository
                .FirstOrDefaultWithCity(adr => adr.Id == id);

            return this.mapper.Map<AddressWithCityDetailsModel>(address);
        }

        public bool Update(AddressWithCityDetailsModel addressWithCityDetailsModel)
        {
            if (addressWithCityDetailsModel == null) return false;

            var address = this.mapper.Map<Address>(addressWithCityDetailsModel);

            try
            {
                this.unitOfWork.AddressRepository.Update(address);
                this.unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(AddressWithCityDetailsModel addressWithCityDetailsModel)
        {
            if (addressWithCityDetailsModel == null) return false;

            var address = this.mapper.Map<Address>(addressWithCityDetailsModel);

            try
            {
                this.unitOfWork.AddressRepository.Delete(address);
                this.unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public bool Add(AddressWithCityDetailsModel addressWithCityDetailsModel)
        {
            if (addressWithCityDetailsModel == null) return false;

            var address = this.mapper.Map<Address>(addressWithCityDetailsModel);

            try
            {
                this.unitOfWork.AddressRepository.Insert(address);
                this.unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<AddressWithCityDetailsModel> GetByCompanyId(int companyId)
        {
            var addresses = this.unitOfWork
                .AddressRepository
                .GetManyWithCity(x => x.CompanyId == companyId);

            return addresses.Select(adr => this.mapper.Map<AddressWithCityDetailsModel>(adr));
        }
    }
}