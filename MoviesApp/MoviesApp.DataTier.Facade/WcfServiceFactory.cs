using Microsoft.Practices.Unity;
using MoviesApp.BizTier;
using Unity.Wcf;

namespace MoviesApp.DataTier.Facade
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
                .RegisterType<IDataService, DataService>()
                .RegisterType<IActorProvider, ActorProvider>()
                .RegisterType<IActorTagProvider, ActorTagProvider>()
                .RegisterType<IMovieProvider, MovieProvider>()
                .RegisterType<IMovieTagProvider, MovieTagProvider>();
        }
    }    
}