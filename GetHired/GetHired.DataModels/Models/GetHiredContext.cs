using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using GetHired.DataModels.Configurations.Contracts;
using GetHired.DataModels.Contracts;
using GetHired.DomainModels;
using GetHired.DomainModels.Contracts;

namespace GetHired.DataModels.Models
{
    public class GetHiredContext : DbContext, IGetHiredContext
    {
        public GetHiredContext()
            : base("name=GetHired")
        { }

        public virtual IDbSet<Address> Addresses { get; set; }
        public virtual IDbSet<JobOffer> JobOffers { get; set; }
        public virtual IDbSet<City> Towns { get; set; }
        public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            this.RegisterConfigurations(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void RegisterConfigurations(DbModelBuilder modelBuilder)
        {
            var type = typeof(IFluentConfiguration);

            var configs = Assembly.GetAssembly(type)
                .GetTypes()
                .Where(x => type.IsAssignableFrom(x) && x.IsClass && !x.IsAbstract);

            foreach (var config in configs)
            {
                var instance = Activator.CreateInstance(config);
                (instance as IFluentConfiguration)?.Register(modelBuilder);
            }
        }

        public override int SaveChanges()
        {
            var dbEntityEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                {
                    var implementsIModificationHistory = e.Entity is IModificationHistory;
                    var isAddedOrModified = e.State == EntityState.Added || e.State == EntityState.Modified;

                    return implementsIModificationHistory && isAddedOrModified;
                })
                .AsEnumerable();

            foreach (var entry in dbEntityEntries)
            {
                if (entry.State == EntityState.Added)
                {
                    (entry.Entity as IModificationHistory).DateCreated = DateTime.Now;
                }
                else
                {
                    entry.Property("DateCreated").IsModified = false;
                }

                (entry.Entity as IModificationHistory).DateModified = DateTime.Now;
            }

            return base.SaveChanges();
        }
    }
}
