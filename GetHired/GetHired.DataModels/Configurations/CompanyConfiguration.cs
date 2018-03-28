using System.Data.Entity;
using GetHired.DataModels.Configurations.Contracts;
using GetHired.DomainModels;

namespace GetHired.DataModels.Configurations
{
    internal class CompanyConfiguration : IFluentConfiguration
    {
        public void Register(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Company>()
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder.Entity<Company>()
                .Property(x => x.Website)
                .HasMaxLength(125)
                .IsRequired();

            modelBuilder.Entity<Company>()
                .HasIndex(x => x.Website)
                .IsUnique();

            modelBuilder.Entity<Company>()
                .Property(x => x.BusinessInfo)
                .HasColumnType("text");

            modelBuilder.Entity<Company>()
                .Property(x => x.PhoneNumber)
                .HasColumnType("VARCHAR")
                .HasMaxLength(10)
                .IsFixedLength();
        }
    }
}