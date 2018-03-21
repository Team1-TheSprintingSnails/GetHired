using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GetHired.DomainModels;

namespace GetHired.DataModels.Repositories.Contracts
{
    public interface ITownRepository
    {
        IEnumerable<Town> GetManyWithAddresses(Expression<Func<Town, bool>> predicate);
        Town GetOneWithAllDetails(Expression<Func<Town, bool>> predicate);
    }
}
