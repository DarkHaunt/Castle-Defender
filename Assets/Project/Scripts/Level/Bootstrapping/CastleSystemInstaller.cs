using Game.Level.Services.Castles;
using Game.Level.Views.Castles;
using Game.Level.Binders;
using VContainer.Unity;
using VContainer;


namespace Game.Level.Bootstrapping
{
    public class CastleSystemInstaller : IInstaller
    {
        private readonly CastleView _castleView;


        public CastleSystemInstaller(CastleView castleView)
        {
            _castleView = castleView;
        }
        

        public void Install(IContainerBuilder builder)
        {
            RegisterCastleView(builder);
            RegisterCastleBinder(builder);
            RegisterCastleService(builder); 
        }

        private void RegisterCastleService(IContainerBuilder builder)
        {
            builder.Register<CastleModel>(Lifetime.Scoped);
        }

        private void RegisterCastleView(IContainerBuilder builder)
        {
            builder.RegisterComponent(_castleView);
        }

        private void RegisterCastleBinder(IContainerBuilder builder)
        {
            builder.Register<CastleBinder>(Lifetime.Scoped);
        }
    }
}