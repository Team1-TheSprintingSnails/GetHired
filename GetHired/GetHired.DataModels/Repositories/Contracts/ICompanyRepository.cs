using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GetHired.DomainModels;

namespace GetHired.DataModels.Repositories.Contracts
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetManyWithAddresses(Expression<Func<Company, bool>> predicate);

        IEnumerable<Company> GetManyWithJobOffers(Expression<Func<Company, bool>> predicate);

        Company GetOneWithAllDetails(Expression<Func<Company, bool>> predicate);
    }
}
