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
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(IGetHiredContext context) : base(context)
        {
        }

        public IEnumerable<Company> GetManyWithAddresses(Expression<Func<Company, bool>> predicate)
        {
            var manyWithAddresses = this.DbSet
                .AsNoTracking()
                .Include(x => x.Addresses)
                .Where(predicate)
                .AsEnumerable();

            return manyWithAddresses;
        }

        public IEnumerable<Company> GetManyWithJobOffers(Expression<Func<Company, bool>> predicate)
        {
            var manyWithJobOffers = this.DbSet
                .AsNoTracking()
                .Include(x => x.JobOffers)
                .Where(predicate)
                .AsEnumerable();

            return manyWithJobOffers;
        }

        public Company GetOneWithAllDetails(Expression<Func<Company, bool>> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Where(predicate)
                .FirstOrDefault();
        }
    }
}
