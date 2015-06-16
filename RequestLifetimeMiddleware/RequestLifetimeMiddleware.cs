using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

using Microsoft.Owin;
using Microsoft.Practices.Unity;

namespace RequestLifetimeMiddleware
{
    public class RequestLifetimeMiddleware : OwinMiddleware
    {
        private readonly IUnityContainer unityContainer;

        public RequestLifetimeMiddleware(OwinMiddleware next, IUnityContainer container)
            : base(next)
        {
            this.unityContainer = container;
        }

        public override async Task Invoke(IOwinContext context)
        {
            // Wait for request
            await base.Next.Invoke(context);

            // Identify child controlled types
            var registrations = unityContainer.Registrations.Where(x => x.LifetimeManager is PerRequestLifetimeManager);

            foreach (var type in registrations)
            {
                // Cleanup PerRequestLifetimeManager's mess
                var instance = unityContainer.Resolve(type.RegisteredType) as IDisposable;
                if (instance != null)
                {
                    instance.Dispose();
                }
            }
        }
    }
}