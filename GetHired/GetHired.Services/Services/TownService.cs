using AutoMapper;
using GetHired.DataModels.Contracts;
using GetHired.DomainModels;
using GetHired.DTO;

using System;

namespace GetHired.Services.Services
{
    public class TownService
    {
        private IUnitOfWork unitOfWork;

        public TownService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddTown(CityModel city)
        {
            if(city == null)
            {
                throw new ArgumentNullException();
            }

            var regularTown = Mapper.Map<City>(city);
            //this.unitOfWork.TownRepository.Insert(regularTown);
        }
    }
}
