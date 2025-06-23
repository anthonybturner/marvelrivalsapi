using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MarvelRivalsFanSiteDotNet
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var serviceProvider = DependencyConfig.ConfigureServices();
            ControllerBuilder.Current.SetControllerFactory(
                new DefaultControllerFactory(new DiControllerActivator(serviceProvider))
            );
        }

        private class DiControllerActivator : IControllerActivator
        {
            private readonly IServiceProvider _serviceProvider;

            public DiControllerActivator(IServiceProvider serviceProvider)
            {
                _serviceProvider = serviceProvider;
            }

            public IController Create(RequestContext requestContext, Type controllerType)
            {
                return (IController)_serviceProvider.GetRequiredService(controllerType);
            }
        }
    }
}
