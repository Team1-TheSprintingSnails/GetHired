using AutoMapper;
using GetHired.DataModels.Contracts;
using GetHired.DomainModels;
using GetHired.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using GetHired.DTO.ViewModels;
using GetHired.Services.Contracts;

namespace GetHired.Services.Services
{
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AddressService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public AddressWithCityViewModel GetByIdWithCity(int id)
        {
            var address = this.unitOfWork
                .AddressRepository
                .FirstOrDefaultWithCity(adr => adr.Id == id);

            return this.mapper.Map<AddressWithCityViewModel>(address);
        }

        public AddressModel GetById(int id)
        {
            var address = this.unitOfWork
                .AddressRepository
                .FirstOrDefaultWithCity(adr => adr.Id == id);

            return this.mapper.Map<AddressModel>(address);
        }

        public bool Update(AddressModel addressWithCityViewModel)
        {
            if (addressWithCityViewModel == null) return false;

            var address = this.mapper.Map<Address>(addressWithCityViewModel);

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

        public bool Delete(AddressModel addressWithCityViewModel)
        {
            if (addressWithCityViewModel == null) return false;

            var address = this.mapper.Map<Address>(addressWithCityViewModel);

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

        public bool DeleteById(int addressId)
        {
            try
            {
                var address = this.unitOfWork.AddressRepository.GetById(addressId);
                this.unitOfWork.AddressRepository.Delete(address);
                this.unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Add(AddressModel addressWithCityViewModel)
        {
            if (addressWithCityViewModel == null) return false;

            var address = this.mapper.Map<Address>(addressWithCityViewModel);

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

        public IEnumerable<AddressModel> GetByCompanyId(int companyId)
        {
            var addresses = this.unitOfWork
                .AddressRepository
                .SearchFor(x => x.CompanyId == companyId);

            return addresses.Select(adr => this.mapper.Map<AddressModel>(adr));
        }
    }
}