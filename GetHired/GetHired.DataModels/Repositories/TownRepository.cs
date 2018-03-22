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
    public class TownRepository : GenericRepository<Town>, ITownRepository
    {
        public TownRepository(IGetHiredContext context) : base(context)
        {
        }

        public IEnumerable<Town> GetManyWithAddresses(Expression<Func<Town, bool>> predicate)
        {
            var manyWithAddresses = this.DbSet
                .AsNoTracking()
                .Include(x => x.Addresses)
                .Where(predicate);

            return manyWithAddresses;
        }

        public Town GetOneWithAllDetails(Expression<Func<Town, bool>> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Where(predicate)
                .FirstOrDefault();
        }
    }
}
