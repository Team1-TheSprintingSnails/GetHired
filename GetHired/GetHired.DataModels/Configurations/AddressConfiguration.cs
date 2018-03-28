using System.Data.Entity;
using GetHired.DataModels.Configurations.Contracts;
using GetHired.DomainModels;

namespace GetHired.DataModels.Configurations
{
    internal class AddressConfiguration : IFluentConfiguration
    {
        public void Register(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .Property(x => x.PostalCode)
                .HasColumnType("VARCHAR")
                .HasMaxLength(4)
                .IsFixedLength()
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(x => x.StreetName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(125)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .HasIndex(p => new { p.PostalCode, p.StreetName })
                .IsUnique();
        }
    }
}