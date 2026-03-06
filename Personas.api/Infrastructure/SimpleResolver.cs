using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace Personas.api.Infrastructure
{
    public class SimpleResolver : IDependencyResolver
    {
        private readonly Dictionary<Type, Func<object>> _services;

        public SimpleResolver(Dictionary<Type, Func<object>> services)
        {
            _services = services;
        }

        public object GetService(Type serviceType)
        {
            if (_services.ContainsKey(serviceType))
                return _services[serviceType]();

            if (serviceType.IsGenericType &&
                serviceType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                var itemType = serviceType.GetGenericArguments()[0];

                if (_services.ContainsKey(itemType))
                {
                    var instance = _services[itemType]();
                    var array = Array.CreateInstance(itemType, 1);
                    array.SetValue(instance, 0);
                    return array;
                }

                return Array.CreateInstance(itemType, 0);
            }

            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            var service = GetService(serviceType);

            if (service == null)
                return Enumerable.Empty<object>();

            if (service is IEnumerable<object> enumerable)
                return enumerable;

            return new[] { service };
        }

        public IDependencyScope BeginScope() => this;

        public void Dispose() { }
    }
}