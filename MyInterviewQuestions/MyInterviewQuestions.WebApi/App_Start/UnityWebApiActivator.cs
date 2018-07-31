//using System.Linq;
//using System.Web.Http;
//using System.Web.Mvc;
//using Unity.AspNet.WebApi;


//[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MyInterviewQuestions.WebApi.UnityWebApiActivator), nameof(MyInterviewQuestions.WebApi.UnityWebApiActivator.Start))]
//[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(MyInterviewQuestions.WebApi.UnityWebApiActivator), nameof(MyInterviewQuestions.WebApi.UnityWebApiActivator.Shutdown))]

//namespace MyInterviewQuestions.WebApi
//{
//    /// <summary>
//    /// Provides the bootstrapping for integrating Unity with WebApi when it is hosted in ASP.NET.
//    /// </summary>
//    public static class UnityWebApiActivator
//    {
//        /// <summary>
//        /// Integrates Unity when the application starts.
//        /// </summary>
//        public static void Start() 
//        {
//            var container = UnityConfig.Container;

//            //FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
//            //FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(container));


//            // Use UnityHierarchicalDependencyResolver if you want to use
//            // a new child container for each IHttpController resolution.
//            // var resolver = new UnityHierarchicalDependencyResolver(UnityConfig.Container);



//            var resolver = new UnityDependencyResolver(container);

//            GlobalConfiguration.Configuration.DependencyResolver = resolver;
//            //DependencyResolver.SetResolver(resolver);
//        }

//        /// <summary>
//        /// Disposes the Unity container when the application is shut down.
//        /// </summary>
//        public static void Shutdown()
//        {
//            UnityConfig.Container.Dispose();
//        }
//    }
//}