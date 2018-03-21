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
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(IGetHiredContext context) : base(context)
        {
        }

        public IEnumerable<Address> GetManyWithTown(Expression<Func<Address, bool>> predicate)
        {
            var manyWithTown = this.DbSet
                .AsNoTracking()
                .Include(x => x.Town)
                .Where(predicate)
                .AsEnumerable();

            return manyWithTown;
        }

        public Address GetOneWithAllDetails(Expression<Func<Address, bool>> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Where(predicate)
                .FirstOrDefault();
        }
    }
}
