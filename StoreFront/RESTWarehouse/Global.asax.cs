using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using RESTWarehouse.Init;
using RESTWarehouse.IoC;

namespace RESTWarehouse
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    
     
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer Container;

        private static void BootstrapContainer()
        {
            Container = new WindsorContainer().Install(FromAssembly.This());
            GlobalConfiguration.Configuration.DependencyResolver = new WindsorDependencyResolver(Container.Kernel);
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BootstrapContainer();

            Container.Resolve<InitStoreData>().InitData();
            
        }
    }
}