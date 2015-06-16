# OwinPerRequestUnityMiddleware
Example of owin middleware that "fixes" Unity's PerRequestLifetimeManager object disposal problem

When use use Unity as your dependency injection container, you have a problem when you start to use Owin. The UnityPerRequestHttpModule cannot be used, which means you have to remove the line `DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));`. This is fine, you're website continues to work and you continue to get one instance per request. However, your objects aren't getting disposed now (which can be pretty serious depending on your objects). He're some middleware that fills that gap.

Download this code and comment out `app.UseUnityMiddleware(UnityConfig.GetConfiguredContainer());` in `Startup` and observe the home page to see how much garbage begins to pile up. 
