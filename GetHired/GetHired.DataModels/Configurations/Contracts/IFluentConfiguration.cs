using System.Data.Entity;

namespace GetHired.DataModels.Configurations.Contracts
{
    public interface IFluentConfiguration
    {
        void Register(DbModelBuilder modelBuilder);
    }
}
