using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GetHired.DomainModels;

namespace GetHired.DataModels.Repositories.Contracts
{
    public interface IJobOfferRepository : IGenericRepository<JobOffer>
    {
        IEnumerable<JobOffer> GetByCompany(string companyName);
        IEnumerable<JobOffer> GetByUser(string userEmail);
        IEnumerable<JobOffer> OrderedByRatingSearchFor(Expression<Func<JobOffer, bool>> predicate);
    }
}
