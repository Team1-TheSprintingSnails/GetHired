using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using GetHired.DomainModels;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DataModels
{
    public interface IGetHiredContext
    {
        IDbSet<Address> Addresses { get; set; }
        IDbSet<Company> Companies { get; set; }
        IDbSet<Contact> Contacts { get; set; }
        IDbSet<JobOffer> JobOffers { get; set; }
        IDbSet<Town> Towns { get; set; }
        IDbSet<User> Users { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry Entry(object entity);
        int SaveChanges();
    }
}