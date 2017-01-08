using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using Atlant.Dependency;
using Microsoft.Practices.Unity;
using Atlant.Bll;

namespace Atlant
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Код, выполняемый при запуске приложения
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            IUnityContainer container = new UnityContainer();
            container.RegisterType<IAtlantService, AtlantService>();
            container.RegisterType<IDetailRepository, DetailRepository>();
            container.RegisterType<IStorekeeperRepository, StorekeeperRepository>();

            DependencyResolver.SetResolver(new AtlantDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AtlantApiDependencyResolver(container);      
        }
    }
}