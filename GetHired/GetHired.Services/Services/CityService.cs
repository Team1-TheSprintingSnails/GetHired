using AutoMapper;
using GetHired.DataModels.Contracts;
using GetHired.DTO;
using System.Collections.Generic;
using System.Linq;
using GetHired.Services.Contracts;

namespace GetHired.Services.Services
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<CityModel> GetAll()
        {
            var cities = this.unitOfWork.CityRepository.All;
            return cities.Select(c => this.mapper.Map<CityModel>(c));
        }
    }
}
