using System.Collections.Generic;
using GetHired.DomainModels;

namespace GetHired.DataModels.Repositories.Contracts
{
    public interface IJobOfferRepository : IGenericRepository<JobOffer>
    {
        IEnumerable<JobOffer> GetByCompanyId(int companyId);
        IEnumerable<JobOffer> GetAllOrderedByRating();
        JobOffer GetJobOfferWithCompany(int jobOfferId);
    }
}
