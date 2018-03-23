using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GetHired.DomainModels;

namespace GetHired.DataModels.Repositories.Contracts
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        IEnumerable<Address> GetManyWithIncludedTown(Expression<Func<Address, bool>> predicate);
        Address GetOneWithIncludedTown(Expression<Func<Address, bool>> predicate);
    }
}
