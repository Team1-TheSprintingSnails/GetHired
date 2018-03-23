using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GetHired.DomainModels;

namespace GetHired.DataModels.Repositories.Contracts
{
    public interface IJobOfferRepository : IGenericRepository<JobOffer>
    {
        IEnumerable<JobOffer> GetManyWithIncludedCompany(Expression<Func<JobOffer, bool>> predicate);
        IEnumerable<JobOffer> GetManyWithIncludedJobDetails(Expression<Func<JobOffer, bool>> predicate);
        JobOffer GetOneWithIncludedJobDetailsAndCompany(Expression<Func<JobOffer, bool>> predicate);
    }
}
