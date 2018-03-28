using System.Data.Entity;
using GetHired.DataModels.Configurations.Contracts;
using GetHired.DomainModels;

namespace GetHired.DataModels.Configurations
{
    internal class CityConfiguration : IFluentConfiguration
    {
        public void Register(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<City>()
                .Property(x => x.State)
                .HasMaxLength(50);

            modelBuilder.Entity<City>()
                .Property(x => x.Country)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}