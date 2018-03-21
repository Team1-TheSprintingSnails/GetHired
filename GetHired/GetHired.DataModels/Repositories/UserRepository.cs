using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using GetHired.DataModels.Contracts;
using GetHired.DomainModels;

namespace GetHired.DataModels.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IGetHiredContext context) : 
            base(context)
        {
        }

        public User GetOneWithFavouriteOffers(int id)
        {
            var oneWithFavouriteOffers = this.DbSet
                .AsNoTracking()
                .Include(x => x.FavouriteJobOffers)
                .FirstOrDefault(x => x.Id == id);

            return oneWithFavouriteOffers;
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

        public void AddJobOfferToUser(JobOffer jobOffer, int userId)
        {
            var user = this.GetById(userId);
            user.FavouriteJobOffers.Add(jobOffer);
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

        public IEnumerable<User> GetManyWithFavouriteOffers(Expression<Func<User, bool>> predicate, int count)
        {
            var manyWithFavouriteOffers = this.DbSet
                .AsNoTracking()
                .Include(x => x.FavouriteJobOffers)
                .Where(predicate)
                .Take(count)
                .AsEnumerable();

            return manyWithFavouriteOffers;
        }
    }
}