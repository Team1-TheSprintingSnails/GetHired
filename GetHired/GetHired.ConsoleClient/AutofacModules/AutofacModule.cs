using Autofac;
using GetHired.DataModels;
using GetHired.DataModels.Contracts;

namespace GetHired.ConsoleClient.AutofacModules
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GetHiredContext>().As<IGetHiredContext>().InstancePerDependency();
        }
    }
}
