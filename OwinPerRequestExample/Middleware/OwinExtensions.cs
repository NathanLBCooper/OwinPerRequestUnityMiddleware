using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Practices.Unity;

using Owin;

namespace OwinPerRequestExample.Middleware
{
    public static class OwinExtensions
    {
        private const string MiddlewareRegistrationKey = "Unity:MiddlewareRegistered";

        public static IAppBuilder UseUnityMiddleware(this IAppBuilder app, IUnityContainer container)
        {
            if (app == null) throw new ArgumentNullException("app");
            if (app.Properties.ContainsKey(MiddlewareRegistrationKey)) return app;

            app.Use<RequestLifetimeMiddleware>(container);

            app.Properties.Add(MiddlewareRegistrationKey, true);

            return app;
        }
    }
}