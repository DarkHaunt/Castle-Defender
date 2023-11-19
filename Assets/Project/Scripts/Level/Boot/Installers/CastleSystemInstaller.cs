using Project.Scripts.Level.Castles;
using VContainer;
using VContainer.Unity;


namespace Project.Scripts.Level.Boot.Installers
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