# OwinPerRequestUnityMiddleware
Example of owin middleware that "fixes" Unity's PerRequestLifetimeManager object disposal problem

When you use Unity as your dependency injection container, you have a problem when you start to use Owin. The UnityPerRequestHttpModule cannot be used, which means you have to remove the line `DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));`. This is fine, you're website continues to work and you continue to get one instance per request. However, your objects aren't getting disposed now (which can be pretty serious depending on your objects). He're some middleware that fills that gap.

Download this code and comment out `app.UseUnityMiddleware(UnityConfig.GetConfiguredContainer());` in `Startup` and observe the home page to see how much garbage begins to pile up. 

For the full story, read about this code on the Solidsoft Blog post "Managing object lifetimes with Owin and Unity":
http://www.reply.eu/solidsoft-reply/en/blog#/solidsoft-reply/en/content/managing-object-lifetimes-with-owin-and-unity
