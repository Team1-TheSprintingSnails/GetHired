using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using GetHired.DataModels.Contracts;
using GetHired.DataModels.Repositories.Contracts;
using GetHired.DomainModels;

namespace GetHired.DataModels.Repositories
{
    public class JobOfferRepository : GenericRepository<JobOffer>, IJobOfferRepository
    {
        public JobOfferRepository(IGetHiredContext context) : base(context)
        {
        }

        public IEnumerable<JobOffer> GetManyWithJobCategory(Expression<Func<JobOffer, bool>> predicate)
        {
            var manyWithJobCategory = this.DbSet
                .AsNoTracking()
                .Include(x => x.JobCategory)
                .Where(predicate)
                .AsEnumerable();

            return manyWithJobCategory;
        }

        public IEnumerable<JobOffer> GetManyWithJobCategory(Expression<Func<JobOffer, bool>> predicate, int count)
        {
            var manyWithJobCategory = this.DbSet
                .AsNoTracking()
                .Include(x => x.JobCategory)
                .Where(predicate)
                .Take(count)
                .AsEnumerable();

            return manyWithJobCategory;
        }

        public IEnumerable<JobOffer> GetManyWithJobType(Expression<Func<JobOffer, bool>> predicate)
        {
            var manyWithJobType = this.DbSet
                .AsNoTracking()
                .Include(x => x.JobType)
                .Where(predicate)
                .AsEnumerable();

            return manyWithJobType;
        }

        public IEnumerable<JobOffer> GetManyWithJobType(Expression<Func<JobOffer, bool>> predicate, int count)
        {
            var manyWithJobType = this.DbSet
                .AsNoTracking()
                .Include(x => x.JobType)
                .Where(predicate)
                .Take(count)
                .AsEnumerable();

            return manyWithJobType;
        }

        public IEnumerable<JobOffer> GetManyWithCompany(Expression<Func<JobOffer, bool>> predicate)
        {
            var manyWithCompany = this.DbSet
                .AsNoTracking()
                .Include(x => x.Company)
                .Where(predicate)
                .AsEnumerable();

            return manyWithCompany;
        }

        public IEnumerable<JobOffer> GetManyWithcompany(Expression<Func<JobOffer, bool>> predicate, int count)
        {
            var manyWithCompany = this.DbSet
                .AsNoTracking()
                .Include(x => x.Company)
                .Where(predicate)
                .Take(count)
                .AsEnumerable();

            return manyWithCompany;
        }

        public JobOffer GetOneWithFullDetails(Expression<Func<JobOffer, bool>> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Where(predicate)
                .FirstOrDefault();
        }
    }
}
