using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using GetHired.DataModels.Contracts;
using GetHired.DomainModels;
using GetHired.DomainModels.Utilities;

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
        public virtual IDbSet<ContactInfo> Contacts { get; set; }
        public virtual IDbSet<Company> Companies { get; set; }
        public virtual IDbSet<JobType> JobTypes { get; set; }
        public virtual IDbSet<JobCategory> JobCategories { get; set; }
        public virtual IDbSet<Password> Passwords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            
            modelBuilder.Entity<JobOffer>()
                .HasOptional(e => e.JobType)
                .WithMany(e => e.JobOffers)
                .HasForeignKey(e => e.JobTypeId);

            modelBuilder.Entity<JobOffer>()
                .HasOptional(e => e.JobCategory)
                .WithMany(e => e.JobOffers)
                .HasForeignKey(e => e.JobCategoryId);

            modelBuilder.Entity<User>()
                .HasRequired(u => u.Password)
                .WithRequiredPrincipal(p => p.User);
        }
    }
}
