using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GetHired.DomainModels;

namespace GetHired.DataModels.Repositories.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetOneWithFavouriteOffers(Expression<Func<User, bool>> predicate);
        IEnumerable<User> GetManyWithFavouriteOffers(Expression<Func<User, bool>> predicate);
        IEnumerable<User> GetManyWithFavouriteOffers(Expression<Func<User, bool>> predicate, int count);
    }
}