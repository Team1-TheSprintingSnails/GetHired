using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GetHired.DomainModels;

namespace GetHired.DataModels.Repositories.Contracts
{
    public interface IJobOfferRepository
    {
        IEnumerable<JobOffer> GetManyWithJobCategory(Expression<Func<JobOffer, bool>> predicate);
        IEnumerable<JobOffer> GetManyWithJobCategory(Expression<Func<JobOffer, bool>> predicate, int count);

        IEnumerable<JobOffer> GetManyWithJobType(Expression<Func<JobOffer, bool>> predicate);
        IEnumerable<JobOffer> GetManyWithJobType(Expression<Func<JobOffer, bool>> predicate, int count);


        IEnumerable<JobOffer> GetManyWithCompany(Expression<Func<JobOffer, bool>> predicate);
        IEnumerable<JobOffer> GetManyWithcompany(Expression<Func<JobOffer, bool>> predicate, int count);

        JobOffer GetOneWithFullDetails(Expression<Func<JobOffer, bool>> predicate);
        JobOffer GetOneWithFullDetails(int id);
    }
}
