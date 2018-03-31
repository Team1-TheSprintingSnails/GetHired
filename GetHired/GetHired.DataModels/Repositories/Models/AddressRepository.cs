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
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(IGetHiredContext context) : base(context)
        {
        }

        public Address FirstOrDefaultWithCity(Expression<Func<Address, bool>> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(x => x.City)
                .FirstOrDefault(predicate);
        }
    }
}
