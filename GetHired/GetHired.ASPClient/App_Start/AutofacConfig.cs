using System;
using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using GetHired.DataModels.Contracts;
using GetHired.Services.Contracts;

namespace GetHired.ASPClient
{
    internal static class AutofacConfig
    {
        private static IContainer container;

        private static IContainer Container
        {
            get
            {
                if (container == null)
                {
                    throw new InvalidOperationException("You must first build the container before accessing it!");
                }

                return container;
            }
        }

        public static IContainer Build()
        {
            var builder = new ContainerBuilder();

            RegisterConventions(builder);

            builder.RegisterControllers(typeof(MvcApplication).Assembly)
                .InstancePerRequest();

            container = builder.Build();
            return container;
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
    }
}

