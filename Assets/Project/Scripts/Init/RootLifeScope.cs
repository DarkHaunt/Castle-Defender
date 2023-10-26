using Game.Common.Interfaces;
using Game.Common.Scene;
using VContainer.Unity;
using VContainer;


namespace Game.Init
{
    public class RootLifeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder
                .RegisterComponentInHierarchy<SceneLoader>()
                .DontDestroyOnLoad();

            builder
                .RegisterComponentInHierarchy<SceneTransitionHandler>()
                .DontDestroyOnLoad();
            
            builder
                .RegisterComponentInHierarchy<CoroutineRunner>()
                .DontDestroyOnLoad()
                .As<ICoroutineRunner>();
        }
    }
}