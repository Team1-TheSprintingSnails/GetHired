using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GetHired.DomainModels;

namespace GetHired.DataModels.Repositories.Contracts
{
    public interface ITownRepository : IGenericRepository<Town>
    {
        IEnumerable<Town> GetManyWithIncludedAddresses(Expression<Func<Town, bool>> predicate);
        Town GetOneWithIncludedAddresses(Expression<Func<Town, bool>> predicate);
    }
}
