using System.Collections.Generic;
using GetHired.DTO;

namespace GetHired.Services.Contracts
{
    interface ICompanyService
    {
        bool Add(CompanyModel model);
        bool Delete(CompanyModel model);
        IEnumerable<CompanyModel> GetAll();
        bool Update(CompanyModel model);
    }
}