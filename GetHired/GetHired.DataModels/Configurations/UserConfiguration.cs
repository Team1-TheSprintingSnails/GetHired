using System.Data.Entity;
using GetHired.DataModels.Configurations.Contracts;
using GetHired.DomainModels;

namespace GetHired.DataModels.Configurations
{
    internal class UserConfiguration : IFluentConfiguration
    {
        public void Register(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(x => x.Email)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.Email)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasIndex(x => x.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .Property(x => x.Email)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.PasswordHash)
                .HasMaxLength(125)
                .IsFixedLength()
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.Role)
                .IsRequired();
        }
    }
}