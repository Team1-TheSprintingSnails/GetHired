using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using GetHired.DataModels.Contracts;
using GetHired.DataModels.Repositories.Contracts;
using GetHired.DomainModels;

namespace GetHired.DataModels.Repositories.Models
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IGetHiredContext context) : 
            base(context)
        {
        }

        public User GetOneWithFavouriteOffers(Expression<Func<User, bool>> predicate)
        {
            var oneWithFavouriteOffers = this.DbSet
                .AsNoTracking()
                .Include(x => x.FavouriteJobOffers)
                .Where(predicate)
                .FirstOrDefault();

            return oneWithFavouriteOffers;
        }

        public IEnumerable<User> GetManyWithFavouriteOffers(Expression<Func<User, bool>> predicate)
        {
            var manyWithFavouriteOffers = this.DbSet
                .AsNoTracking()
                .Include(x => x.FavouriteJobOffers)
                .Where(predicate)
                .AsEnumerable();

            return manyWithFavouriteOffers;
        }
    }
}