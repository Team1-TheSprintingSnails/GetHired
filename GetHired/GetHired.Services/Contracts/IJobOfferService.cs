using System.Collections.Generic;
using GetHired.DTO;
using GetHired.DTO.ViewModels;

namespace GetHired.Services.Contracts
{
    public interface IJobOfferService
    {
        bool Add(JobOfferModel model);
        bool Delete(JobOfferModel model);
        IEnumerable<JobOfferModel> GetAll();
        IEnumerable<JobOfferModel> GetByCompanyId(int companyId);
        JobOfferWithCompanyViewModel GetById(int jobOfferId);
        IEnumerable<JobOfferModel> GetByUserId(int userId);
        bool Update(JobOfferModel model);
        bool DeleteById(int jobOfferId);
    }
}