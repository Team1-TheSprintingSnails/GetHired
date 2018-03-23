using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using GetHired.DataModels.Contracts;
using GetHired.DataModels.Repositories.Contracts;
using GetHired.DomainModels;

namespace GetHired.DataModels.Repositories.Models
{
    public class JobOfferRepository : GenericRepository<JobOffer>, IJobOfferRepository
    {
        public JobOfferRepository(IGetHiredContext context) : base(context)
        {
        }

        public IEnumerable<JobOffer> GetManyWithIncludedJobDetails(Expression<Func<JobOffer, bool>> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(x => x.JobType)
                .Include(x => x.JobCategory)
                .Where(predicate)
                .AsEnumerable();
        }

        public IEnumerable<JobOffer> GetManyWithIncludedCompany(Expression<Func<JobOffer, bool>> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(x => x.Company)
                .Where(predicate);
        }

        public JobOffer GetOneWithIncludedJobDetailsAndCompany(Expression<Func<JobOffer, bool>> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(x => x.Company)
                .Include(x => x.JobCategory)
                .Include(x => x.JobType)
                .FirstOrDefault(predicate);
        }
    }
}
