using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Practices.Unity;

using Owin;

namespace RequestLifetimeMiddleware
{
    public static class OwinExtensions
    {
        private const string MiddlewareRegistrationKey = "RequestLifetime:MiddlewareRegistered";

        public static IAppBuilder UseRequestLifetimeMiddleware(this IAppBuilder app, IUnityContainer container)
        {
            if (app == null) throw new ArgumentNullException("app");
            if (app.Properties.ContainsKey(MiddlewareRegistrationKey)) return app;

            app.Use<RequestLifetimeMiddleware>(container);

            app.Properties.Add(MiddlewareRegistrationKey, true);

            return app;
        }
    }
}