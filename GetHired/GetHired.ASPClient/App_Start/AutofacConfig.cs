using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using GetHired.ASPClient.Identity_Providers;
using GetHired.DataModels.Contracts;
using GetHired.DataModels.Repositories.Contracts;
using GetHired.Services.Contracts;
using GetHired.Utils.Contracts;
using IdentityDemoWithIoC;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

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

            RegisterIdentityProviders(builder);

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

            var utilsAssembly = Assembly.GetAssembly(typeof(IFileWriter));
            builder.RegisterAssemblyTypes(utilsAssembly)
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

        private static void RegisterIdentityProviders(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>()
                .InstancePerDependency();

            builder.RegisterType<ApplicationUserStore>()
                .As<IUserStore<ApplicationUser>>()
                .InstancePerDependency();

            builder.RegisterType<ApplicationUserManager>()
                .InstancePerDependency();

            builder.RegisterType<ApplicationSignInManager>()
                .InstancePerDependency();

            builder.Register(x => HttpContext.Current.GetOwinContext()?.Authentication 
                ?? new OwinContext().Authentication).InstancePerDependency();
        }
    }
}

