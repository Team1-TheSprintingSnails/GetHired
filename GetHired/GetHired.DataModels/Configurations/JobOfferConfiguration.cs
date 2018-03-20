using System.Data.Entity;
using GetHired.DataModels.Configurations.Contracts;
using GetHired.DomainModels;

namespace GetHired.DataModels.Configurations
{
    public class JobOfferConfiguration : IFluentConfiguration
    {
        public void Register(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobOffer>()
                .HasOptional(e => e.JobType)
                .WithMany(e => e.JobOffers)
                .HasForeignKey(e => e.JobTypeId);

            modelBuilder.Entity<JobOffer>()
                .HasOptional(e => e.JobCategory)
                .WithMany(e => e.JobOffers)
                .HasForeignKey(e => e.JobCategoryId);
        }
    }
}
