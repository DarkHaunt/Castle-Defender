using Game.Level.Installers;
using Game.Level.StateMachine.States.Factories;
using Game.Level.Params.Castles;
using Game.Level.Weapons.HandlePoints;
using Game.Level.StateMachine.States;
using System.Collections.Generic;
using Game.Level.Views.Weapons;
using Game.Level.StateMachine;
using Game.Level.Views.Castles;
using Game.Level.Weapons;
using VContainer.Unity;
using UnityEngine;
using VContainer;


namespace Game.Level.Bootstrappers
{
    public class LevelBootstrapper : LifetimeScope
    {
        [Header("--- Weapon Params ---")]
        [SerializeField] private Weapon _creationPrefab;
        [SerializeField] private Transform _weaponParent;
        [SerializeField] private WeaponSystemView _weaponSystemView;
        [SerializeField] private List<WeaponHandlePoint> _weaponPlacePoints;

        [Header("--- Castle Params ---")]
        [SerializeField] private DebugCastleParamsProvider _castleParamsProvider;
        [SerializeField] private CastleView _castleView;

        
        protected override void Configure(IContainerBuilder builder)
        {
            new WeaponSystemInstaller(_creationPrefab, _weaponParent, _weaponSystemView, _weaponPlacePoints)
                .Install(builder);
            
            new CastleSystemInstaller(_castleParamsProvider, _castleView)
                .Install(builder);
            
            RegisterStates(builder);
            RegisterStateMachine(builder);
            RegisterStateFactories(builder);
            
            Debug.Log($"<color=white>Level</color>");
        }

        private void RegisterStateMachine(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<LevelStateMachine>();
        }
        
        private void RegisterStates(IContainerBuilder builder)
        {
            builder.Register<StartLevelState>(Lifetime.Singleton);
            builder.Register<EndLevelState>(Lifetime.Singleton);
        }

        private void RegisterStateFactories(IContainerBuilder builder)
        {
            builder.Register<StartLevelStateFactory>(Lifetime.Singleton);
            builder.RegisterFactory<IStateSwitcher, StartLevelState>(container => 
                container.Resolve<StartLevelStateFactory>().CreateState, Lifetime.Singleton);        

            builder.Register<EndLevelStateFactory>(Lifetime.Singleton);
            builder.RegisterFactory<EndLevelState>(container => 
                container.Resolve<EndLevelStateFactory>().CreateState, Lifetime.Singleton);
        }
    }
}