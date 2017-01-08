using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;

namespace Atlant.Dependency
{
   public class AtlantApiDependencyResolver: IDependencyResolver
    {
        
            readonly IUnityContainer _container;

            public AtlantApiDependencyResolver(IUnityContainer container)
            {
                _container = container;
            }

        public IDependencyScope BeginScope()
        {
            var child = _container.CreateChildContainer();
            return new AtlantApiDependencyResolver(child);
        }

        public void Dispose()
        {
            _container.Dispose();
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

