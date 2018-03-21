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
            return this.GetOneWithFavouriteOffers(x => x.Id == id);
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

        /// <summary>
        /// Updates relationship between existing JobOffer and User. JobOffer must be already in database. 
        /// </summary>
        /// <param name="jobOffer"></param>
        /// <param name="userId"></param>
        public void AttachJobOfferToUser(JobOffer jobOffer, int userId)
        {
            var user = this.DbSet.Find(userId);

            if (user == null)
            {
                throw new ArgumentException($"User with id {userId} not found in database!");
            }
            
            this.Context.Entry(jobOffer).State = EntityState.Unchanged;
            user.FavouriteJobOffers.Add(jobOffer);
        }

        /// <summary>
        /// Insert new JobOffer to User. SQL INSERT is performed on JobOffer.
        /// </summary>
        /// <param name="jobOffer"></param>
        /// <param name="userId"></param>
        public void InsertJobOfferToUser(JobOffer jobOffer, int userId)
        {
            var user = this.DbSet.Find(userId);

            if (user == null)
            {
                throw new ArgumentException($"User with id {userId} not found in database!");
            }

            this.Context.Entry(jobOffer).State = EntityState.Added;
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