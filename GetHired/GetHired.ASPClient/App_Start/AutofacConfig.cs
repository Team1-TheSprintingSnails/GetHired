using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using GetHired.DataModels.Contracts;
using GetHired.Services.Contracts;

namespace GetHired.ASPClient
{
    internal static class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            RegisterConventions(builder);

            RegisterControllers(builder);

            RegisterMapper(builder);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterConventions(ContainerBuilder builder)
        {
            var dataModelsAssembly = Assembly.GetAssembly(typeof(IGetHiredContext));
            builder.RegisterAssemblyTypes(dataModelsAssembly)
                .AsImplementedInterfaces();

            var servicesAssembly = Assembly.GetAssembly(typeof(IJobOfferService));
            builder.RegisterAssemblyTypes(servicesAssembly)
                .AsImplementedInterfaces();
        }

        private static void RegisterMapper(ContainerBuilder builder)
        {
            builder.Register(m => Mapper.Instance);
        }

        private static void RegisterControllers(ContainerBuilder builder)
        {
            builder.RegisterControllers(typeof(MvcApplication).Assembly)
                .InstancePerRequest();
        }
    }
}

