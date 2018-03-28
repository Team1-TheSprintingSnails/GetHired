using System.Data.Entity;
using GetHired.DataModels.Configurations.Contracts;
using GetHired.DomainModels;

namespace GetHired.DataModels.Configurations
{
    internal class JobOfferConfiguration : IFluentConfiguration
    {
        public void Register(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobOffer>()
                .Property(x => x.Position)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<JobOffer>()
                .Property(x => x.Description)
                .HasColumnType("text");

            modelBuilder.Entity<JobOffer>()
                .Property(x => x.Payment)
                .HasPrecision(20, 2);

            modelBuilder.Entity<JobOffer>()
                .Property(x => x.Rating)
                .HasPrecision(2, 1);
        }
    }
}
