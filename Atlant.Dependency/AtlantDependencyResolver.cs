using Atlant.Bll;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Atlant.Dependency
{
    public class AtlantDependencyResolver : IDependencyResolver
    {
        readonly IUnityContainer _container;

        public AtlantDependencyResolver(IUnityContainer container)
        {
            _container = container;
           
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);
            }
            catch
            {
                return null;
            }
        }
    }

}
