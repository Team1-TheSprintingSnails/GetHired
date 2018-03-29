using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using System.Data.Entity;
using GetHired.DataModels.Models;

namespace GetHired.ASPClient
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<GetHiredContext>(new DropCreateDatabaseIfModelChanges<GetHiredContext>());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig.Configure();

            var container = AutofacConfig.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
