using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using GetHired.DataModels.Configurations.Contracts;
using GetHired.DataModels.Contracts;
using GetHired.DomainModels;

namespace GetHired.DataModels
{
    public class GetHiredContext : DbContext, IGetHiredContext
    {
        public GetHiredContext()
            : base("name=GetHired")
        { }

        public virtual IDbSet<Address> Addresses { get; set; }
        public virtual IDbSet<JobOffer> JobOffers { get; set; }
        public virtual IDbSet<Town> Towns { get; set; }
        public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<Company> Companies { get; set; }
        public virtual IDbSet<JobType> JobTypes { get; set; }
        public virtual IDbSet<JobCategory> JobCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //modelBuilder.Entity<JobOffer>()
            //    .HasOptional(e => e.JobType)
            //    .WithMany(e => e.JobOffers)
            //    .HasForeignKey(e => e.JobTypeId);

            //modelBuilder.Entity<JobOffer>()
            //    .HasOptional(e => e.JobCategory)
            //    .WithMany(e => e.JobOffers)
            //    .HasForeignKey(e => e.JobCategoryId);

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
    }
}
