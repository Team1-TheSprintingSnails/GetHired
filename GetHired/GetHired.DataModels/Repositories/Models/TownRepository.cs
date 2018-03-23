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
    public class TownRepository : GenericRepository<Town>, ITownRepository
    {
        public TownRepository(IGetHiredContext context) : base(context)
        {
        }

        public IEnumerable<Town> GetManyWithIncludedAddresses(Expression<Func<Town, bool>> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(x => x.Addresses)
                .Where(predicate);
        }

        public Town GetOneWithIncludedAddresses(Expression<Func<Town, bool>> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(x => x.Addresses)
                .FirstOrDefault(predicate);
        }
    }
}
