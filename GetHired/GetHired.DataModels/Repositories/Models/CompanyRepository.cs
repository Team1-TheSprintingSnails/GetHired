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
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(IGetHiredContext context) : base(context)
        {
        }

        public IEnumerable<Company> GetManyWithIncludedAddresses(Expression<Func<Company, bool>> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(x => x.Addresses)
                .Where(predicate);
        }

        public Company GetOneWithIncludedAddresses(Expression<Func<Company, bool>> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(x => x.Addresses)
                .FirstOrDefault(predicate);
        }

        public IEnumerable<Company> GetManyWithIncludedJobOffers(Expression<Func<Company, bool>> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(x => x.JobOffers)
                .Where(predicate);
        }

        public Company GetOneWithIncludedJobOffers(Expression<Func<Company, bool>> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(x => x.JobOffers)
                .FirstOrDefault(predicate);
        }
    }
}
