using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GetHired.DomainModels;

namespace GetHired.DataModels.Repositories.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        User GetOneWithFavouriteOffers(int id);
        User GetOneWithFavouriteOffers(Expression<Func<User, bool>> predicate);
        void AttachJobOfferToUser(JobOffer jobOffer, int userId);
        void InsertJobOfferToUser(JobOffer jobOffer, int userId);
        IEnumerable<User> GetManyWithFavouriteOffers(Expression<Func<User, bool>> predicate);
        IEnumerable<User> GetManyWithFavouriteOffers(Expression<Func<User, bool>> predicate, int count);
    }
}