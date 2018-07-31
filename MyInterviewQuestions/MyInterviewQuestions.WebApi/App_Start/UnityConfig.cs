using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using MyInterviewQuestions.Core;
using MyInterviewQuestions.Data;
using MyInterviewQuestions.Service;
using MyInterviewQuestions.WebApi.Framework;
using System;
using System.Web;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace MyInterviewQuestions.WebApi
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

            // context
            container.RegisterType<IDbContext, MyInterviewQuestionsContext>(new PerResolveLifetimeManager());

            // repository
            container.RegisterType(typeof(IRepository<>), typeof(EfRepository<>));
            container.RegisterType<IIdentityRepository, IdentityRepository>();

            container.RegisterType<IAuthenticationManager>(new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));
            container.RegisterType<IUserStore<User, int>, IdentityRepository>(new InjectionConstructor(typeof(IDbContext)));

            //container.RegisterType<UserManager<User, int>, ApplicationUserManager>(new InjectionConstructor(typeof(IdentityRepository)));
            container.RegisterType<ApplicationUserManager>();

            // questions
            container.RegisterType<IQuestionService, QuestionService>();
        }
    }
}