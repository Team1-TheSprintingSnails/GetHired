using System.Data.Entity;

namespace GetHired.DataModels.Configurations.Contracts
{
    internal interface IFluentConfiguration
    {
        void Register(DbModelBuilder modelBuilder);
    }
}
