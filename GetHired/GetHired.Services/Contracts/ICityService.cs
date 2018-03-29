using System.Collections.Generic;
using GetHired.DTO;

namespace GetHired.Services.Contracts
{
    public interface ICityService
    {
        IEnumerable<CityModel> GetAll();
    }
}