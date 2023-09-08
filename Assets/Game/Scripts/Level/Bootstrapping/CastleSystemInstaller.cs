using Game.Level.Binders;
using Game.Level.Params.Castles;
using Game.Level.Services.Castles;
using Game.Level.Views.Castles;
using VContainer;
using VContainer.Unity;


namespace Game.Level.Bootstrapping
{
    public class CastleSystemInstaller : IInstaller
    {
        private readonly DebugCastleParamsProvider _castleParamsProvider;
        private readonly CastleView _castleView;


        public CastleSystemInstaller(DebugCastleParamsProvider castleParamsProvider, CastleView castleView)
        {
            _castleParamsProvider = castleParamsProvider;
            _castleView = castleView;
        }
        

        public void Install(IContainerBuilder builder)
        {
            RegisterCastleView(builder);
            RegisterCastleBinder(builder);
            RegisterCastleService(builder); 

            RegisterCastleParamsProvider(builder);
        }

        private void RegisterCastleService(IContainerBuilder builder)
        {
            builder
                .Register<CastleService>(Lifetime.Singleton)
                .As<ICastleService>();
        }

        private void RegisterCastleView(IContainerBuilder builder)
        {
            builder.RegisterComponent(_castleView);
        }

        private void RegisterCastleBinder(IContainerBuilder builder)
        {
            builder.Register<CastleBinder>(Lifetime.Singleton);
        }

        private void RegisterCastleParamsProvider(IContainerBuilder builder)
        {
            builder
                .RegisterComponent(_castleParamsProvider)
                .As<ICastleParamsProvider>();
        }
    }
}