using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public IEnumerable<JobOffer> GetByCompanyId(int companyId)
        {
            return this.DbSet
                .AsNoTracking()
                .Where(x => x.Company.Id.Equals(companyId));
        }

        public IEnumerable<JobOffer> GetByUserId(int userId)
        {
            return this.DbSet
                .AsNoTracking()
                .Where(x => x.LikedBy.Any(u => u.Id.Equals(userId)));
        }

        public IEnumerable<JobOffer> GetAllOrderedByRating()
        {
            return this.DbSet
                .AsNoTracking()
                .OrderBy(x => x.Rating);
        }

        public JobOffer GetJobOfferWithCompany(int jobOfferId)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(x => x.Company)
                .FirstOrDefault(x => x.Id.Equals(jobOfferId));
        }
    }
}
