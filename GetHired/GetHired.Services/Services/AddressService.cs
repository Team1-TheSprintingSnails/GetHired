using AutoMapper;
using GetHired.DataModels.Contracts;
using GetHired.DomainModels;
using GetHired.DTO;
using System;

namespace GetHired.Services.Services
{
    class AddressService
    {
        private IUnitOfWork unitOfWork;

        public AddressService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddAddress(AddressModel address)
        {
            if (address == null)
            {
                throw new ArgumentNullException();
            }

            var regularAddress = Mapper.Map<Address>(address);
            //this.unitOfWork.AddressRepository.Insert(regularAddress);
        }
    }
}