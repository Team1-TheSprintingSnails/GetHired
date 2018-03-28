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
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        public CityRepository(IGetHiredContext context) : base(context)
        {
        }

        public IEnumerable<City> GetManyWithIncludedAddresses(Expression<Func<City, bool>> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(x => x.Addresses)
                .Where(predicate);
        }

        public City GetOneWithIncludedAddresses(Expression<Func<City, bool>> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(x => x.Addresses)
                .FirstOrDefault(predicate);
        }
    }
}
