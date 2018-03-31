using System.Collections.Generic;
using GetHired.DTO;

namespace GetHired.Services.Contracts
{
    public interface IAddressService
    {
        bool Add(AddressModel addressWithCityViewModel);
        bool Delete(AddressModel addressWithCityViewModel);
        IEnumerable<AddressModel> GetByCompanyId(int companyId);
        AddressWithCityModel GetByIdWithCity(int id);
        AddressModel GetById(int id);
        bool Update(AddressModel addressWithCityViewModel);
        bool DeleteById(int addressId);
    }
}