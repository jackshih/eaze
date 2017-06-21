using System.Web.Http;
using Interview.Green.Web.Scrapper.Interfaces;
using Interview.Green.Web.Scrapper.Service;
using Microsoft.Practices.Unity;

namespace Interview.Green.Web.Scrapper
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IDataRepo, DataRepoService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new {id = RouteParameter.Optional}
                );

            // This endpoint will be hit very heavily, so it has been asked that we implement a job scheduler.
            JobScheduler.Start(); 
        }
    }
}