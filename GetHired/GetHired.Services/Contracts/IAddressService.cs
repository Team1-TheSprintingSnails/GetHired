using System.Collections.Generic;
using GetHired.DTO;
using GetHired.DTO.ViewModels;

namespace GetHired.Services.Contracts
{
    public interface IAddressService
    {
        bool Add(AddressModel addressWithCityViewModel);
        bool Delete(AddressModel addressWithCityViewModel);
        IEnumerable<AddressModel> GetByCompanyId(int? companyId);
        AddressWithCityViewModel GetById(int id);
        bool Update(AddressModel addressWithCityViewModel);
    }
}