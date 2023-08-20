using Game.Level.Common.Triggers;
using Game.Level.Castles;
using VContainer.Unity;
using UnityEngine;
using VContainer;


namespace Game.Level.Weapons.Core
{
    public class CastleSystemBootstrapper : LifetimeScope
    {
        [SerializeField] private float _health;
        [SerializeField] private CollisionObserver _castle;
        
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder
                .Register<Castle>(Lifetime.Singleton)
                .As<ICastle>();
        }
    }
}