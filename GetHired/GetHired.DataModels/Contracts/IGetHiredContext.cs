using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using GetHired.DomainModels;

namespace GetHired.DataModels.Contracts
{
    public interface IGetHiredContext
    {
        IDbSet<Address> Addresses { get; set; }
        IDbSet<Company> Companies { get; set; }
        IDbSet<JobOffer> JobOffers { get; set; }
        IDbSet<City> Towns { get; set; }
        IDbSet<User> Users { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry Entry(object entity);

        int SaveChanges();
    }
}