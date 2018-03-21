using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GetHired.DataModels.Repositories.Contracts;
using GetHired.DomainModels;

namespace GetHired.DataModels.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetOneWithFavouriteOffers(int id);
        User GetOneWithFavouriteOffers(Expression<Func<User, bool>> predicate);
        void AddJobOfferToUser(JobOffer jobOffer, int userId);
        IEnumerable<User> GetManyWithFavouriteOffers(Expression<Func<User, bool>> predicate);
        IEnumerable<User> GetManyWithFavouriteOffers(Expression<Func<User, bool>> predicate, int count);
    }
}