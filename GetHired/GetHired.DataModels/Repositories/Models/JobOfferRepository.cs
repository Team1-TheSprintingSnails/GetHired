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

        public IEnumerable<JobOffer> GetByCompany(string companyName)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(x => x.Company)
                .Where(x => x.Company.Name.Equals(companyName));
        }

        public IEnumerable<JobOffer> GetByUser(string userEmail)
        {
            return this.DbSet
                .Include(x => x.Company)
                .Where(x => x.LikedBy.Any(u => u.Email.Equals(userEmail)));
        }

        public IEnumerable<JobOffer> OrderedByRatingSearchFor(Expression<Func<JobOffer, bool>> predicate)
        {
            return this.DbSet
                .Include(x => x.Company)
                .Where(predicate)
                .OrderBy(x => x.Rating);
        }
    }
}
