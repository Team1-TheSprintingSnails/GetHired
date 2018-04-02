using System.Collections.Generic;
using GetHired.DTO;

namespace GetHired.Services.Contracts
{
    public interface IJobOfferService
    {
        bool Add(JobOfferModel model);
        bool Delete(JobOfferModel model);
        IEnumerable<JobOfferModel> GetAll();
        IEnumerable<JobOfferModel> GetByCompanyId(int companyId);
        JobOfferWithCompanyModel GetByIdWithCompany(int jobOfferId);
        JobOfferModel GetById(int jobOfferId);
        bool Update(JobOfferModel model);
        bool DeleteById(int jobOfferId);
    }
}