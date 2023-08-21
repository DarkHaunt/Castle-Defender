using Game.Level.Services.Castles;
using Game.Level.Params.Castles;
using Game.Level.Views.Castles;
using Game.Level.Binders;
using VContainer.Unity;
using UnityEngine;
using VContainer;


namespace Game.Level.Bootstrappers
{
    public class CastleSystemBootstrapper : LifetimeScope
    {
        [SerializeField] private DebugCastleParamsProvider _castleParamsProvider;
        [SerializeField] private CastleView _castleView;
        
        
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterCastleView(builder);
            RegisterCastleBinder(builder);
            RegisterCastleService(builder); 

            RegisterCastleParamsProvider(builder);
        }

        private void RegisterCastleService(IContainerBuilder builder)
        {
            builder
                .Register<Castle>(Lifetime.Singleton)
                .As<ICastle>();
        }

        private void RegisterCastleView(IContainerBuilder builder)
        {
            builder.RegisterComponent(_castleView);
        }

        private void RegisterCastleBinder(IContainerBuilder builder)
        {
            builder.Register<CastleBinder>(Lifetime.Transient);
        }

        private void RegisterCastleParamsProvider(IContainerBuilder builder)
        {
            builder
                .RegisterComponent(_castleParamsProvider)
                .As<ICastleParamsProvider>();
        }
    }
}