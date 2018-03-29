using System.Collections.Generic;
using GetHired.DTO;

namespace GetHired.Services.Contracts
{
    public interface ICompanyService
    {
        bool Add(CompanyModel model);
        bool Delete(CompanyModel model);
        IEnumerable<CompanyModel> GetAll();
        bool Update(CompanyModel model);
        CompanyModel GetById(int companyId);
        bool DeleteById(int companyId);
    }
}