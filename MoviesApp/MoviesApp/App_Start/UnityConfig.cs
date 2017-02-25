using Microsoft.Practices.Unity;
using System.Web.Http;
using MoviesApp.AppTier.Bridge;
using Unity.WebApi;
using MoviesApp.AppTier.Bridge.BizService;
using MoviesApp.Controllers;

namespace MoviesApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container
                .RegisterType<IActorCoupler, ActorCoupler>()
                .RegisterType<IActorTagCoupler, ActorTagCoupler>()
                .RegisterType<IMovieCoupler, MovieCoupler>()
                .RegisterType<IMovieTagCoupler, MovieTagCoupler>()
                .RegisterType<IBizService, BizServiceClient>(new InjectionConstructor())
                .RegisterType<IMovieController, MovieController>();
                //.RegisterType<IDataService, DataServiceClient>(new InjectionConstructor());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}