using Game.Level.Views.Castles;
using Game.Level.Views.Weapons;
using Game.Common.Interfaces;
using Game.Common.Physics;
using Game.Level.Weapons;
using VContainer.Unity;
using UnityEngine;
using VContainer;


namespace Game.Level.Bootstrapping
{
    public class LevelLifeScope : LifetimeScope
    {
        [Header("--- Main ---")]
        [SerializeField] private LevelBootstrapper _bootstrapper;
        [SerializeField] private CoroutineRunner _coroutineRunner;

        [Header("--- Parent Objects---")]
        [SerializeField] private Transform _weaponParent;
        [SerializeField] private Transform _levelParent;
        [SerializeField] private Transform _enemyParent;
        
        [Header("--- Views ---")]
        [SerializeField] private WeaponSystemView _weaponSystemView;
        [SerializeField] private CastleView _castleView;
        
        [Header("--- TEMP ---")]
        [SerializeField] private Weapon _creationPrefab;


        protected override void Configure(IContainerBuilder builder)
        {
            RegisterLevelCollisionService(builder);
            RegisterCoroutineRunner(builder);
            
            new WeaponSystemInstaller(_creationPrefab, _weaponParent, _weaponSystemView)
                .Install(builder);

            new CastleSystemInstaller(_castleView)
                .Install(builder);

            new EnemySystemInstaller(_enemyParent)
                .Install(builder);

            new LevelSystemInstaller(_bootstrapper, _levelParent)
                .Install(builder);
        }

        private void RegisterCoroutineRunner(IContainerBuilder builder)
        {
            builder
                .RegisterComponentInNewPrefab(_coroutineRunner, Lifetime.Scoped)
                .UnderTransform(_levelParent)
                .As<ICoroutineRunner>();
        }

        private void RegisterLevelCollisionService(IContainerBuilder builder)
        {
            builder.Register<LevelCollisionsService>(Lifetime.Singleton);
        }
    }
}