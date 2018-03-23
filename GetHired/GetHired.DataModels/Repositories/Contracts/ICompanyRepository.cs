using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GetHired.DomainModels;

namespace GetHired.DataModels.Repositories.Contracts
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Company GetOneWithIncludedAddresses(Expression<Func<Company, bool>> predicate);

        Company GetOneWithIncludedJobOffers(Expression<Func<Company, bool>> predicate);

        IEnumerable<Company> GetManyWithIncludedAddresses(Expression<Func<Company, bool>> predicate);

        IEnumerable<Company> GetManyWithIncludedJobOffers(Expression<Func<Company, bool>> predicate);
    }
}
