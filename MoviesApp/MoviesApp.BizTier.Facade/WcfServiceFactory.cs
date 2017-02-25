using Microsoft.Practices.Unity;
using MoviesApp.BizTier.Bridge;
using MoviesApp.BizTier.Bridge.DataService;
using Unity.Wcf;

namespace MoviesApp.BizTier.Facade
{
	public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
			// register all your components with the container here
            // container
            //    .RegisterType<IService1, Service1>()
            //    .RegisterType<DataContext>(new HierarchicalLifetimeManager());
            container
                .RegisterType<IBizService, BizService>()
                .RegisterType<IDataService, DataServiceClient>(new InjectionConstructor())
                .RegisterType<IActorProcessor, ActorProcessor>()
                .RegisterType<IActorTagProcessor, ActorTagProcessor>()
                .RegisterType<IMovieProcessor, MovieProcessor>()
                .RegisterType<IMovieTagProcessor, MovieTagProcessor>()
                .RegisterType<IActorConnector, ActorConnector>()
                .RegisterType<IMovieConnector, MovieConnector>()
                .RegisterType<IMovieTagConnector, MovieTagConnector>()
                .RegisterType<IActorTagConnector, ActorTagConnector>();
        }
    }    
}