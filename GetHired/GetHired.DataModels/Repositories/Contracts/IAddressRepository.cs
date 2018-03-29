using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GetHired.DomainModels;

namespace GetHired.DataModels.Repositories.Contracts
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Address FirstOrDefaultWithCity(Expression<Func<Address, bool>> predicate);
    }
}
