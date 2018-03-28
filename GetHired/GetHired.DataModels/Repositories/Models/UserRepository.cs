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
        
        public User GetByEmail(string email)
        {
            return this.DbSet
                .AsNoTracking()
                .FirstOrDefault(x => x.Email == email);
        }
    }
}