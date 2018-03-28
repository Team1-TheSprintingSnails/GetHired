using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GetHired.DomainModels;

namespace GetHired.DataModels.Repositories.Contracts
{
    public interface ICityRepository : IGenericRepository<City>
    {
        IEnumerable<City> GetManyWithIncludedAddresses(Expression<Func<City, bool>> predicate);
        City GetOneWithIncludedAddresses(Expression<Func<City, bool>> predicate);
    }
}
