using AutoMapper;
using GetHired.DataModels.Contracts;
using GetHired.DomainModels;
using GetHired.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GetHired.Services.Services
{
    class AddressService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AddressService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public AddressModel GetById(int id)
        {
            var address = this.unitOfWork
                .AddressRepository
                .FirstOrDefaultWithCity(adr => adr.Id == id);

            return this.mapper.Map<AddressModel>(address);
        }

        public bool Update(AddressModel addressModel)
        {
            if (addressModel == null) return false;

            var address = this.mapper.Map<Address>(addressModel);

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

        public bool Delete(AddressModel addressModel)
        {
            if (addressModel == null) return false;

            var address = this.mapper.Map<Address>(addressModel);

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
        
        public bool Add(AddressModel addressModel)
        {
            if (addressModel == null) return false;

            var address = this.mapper.Map<Address>(addressModel);

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
    }
}