using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

using RequestLifetimeMiddleware;

[assembly: OwinStartup(typeof(OwinPerRequestExample.App_Start.Startup))]

namespace OwinPerRequestExample.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseUnityMiddleware(UnityConfig.GetConfiguredContainer());
        }
    }
}
