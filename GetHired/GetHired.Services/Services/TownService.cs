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

        public void AddTown(TownModel town)
        {
            if(town == null)
            {
                throw new ArgumentNullException();
            }

            var regularTown = Mapper.Map<Town>(town);
            //this.unitOfWork.TownRepository.Insert(regularTown);
        }
    }
}
