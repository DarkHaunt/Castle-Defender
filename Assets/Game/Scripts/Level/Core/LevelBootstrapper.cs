using Game.Level.StateMachine.States.Factories;
using Game.Level.StateMachine.States;
using System.Collections.Generic;
using Game.Level.Weapons.Create;
using Game.Level.StateMachine;
using Game.Level.Weapons;
using VContainer.Unity;
using UnityEngine;
using VContainer;


namespace Game.Level.Core
{
    public class LevelBootstrapper : LifetimeScope
    {
        [Header("--- Weapon Views ---")]
        [SerializeField] private Transform _weaponParent;
        [SerializeField] private WeaponCreationView _weaponCreationView;
        [SerializeField] private List<WeaponCreatePoint> _weaponPlacePoints;
        
        
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterStates(builder);
            RegisterStateMachine(builder);
            RegisterStateFactories(builder);

            RegisterWeaponCreationSystem(builder);
        }

        private void RegisterStateMachine(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<LevelStateMachine>();
        }

        private void RegisterWeaponCreationSystem(IContainerBuilder builder)
        {
            builder
                .Register<WeaponCreationService>(Lifetime.Singleton)
                .WithParameter<IEnumerable<WeaponCreatePoint>>(_weaponPlacePoints);
            
            builder
                .Register<WeaponFactory>(Lifetime.Singleton)
                .WithParameter(_weaponParent);
            
            builder.Register<WeaponCreationBinder>(Lifetime.Singleton);
            builder.RegisterComponent(_weaponCreationView);
        }
        
        private void RegisterStates(IContainerBuilder builder)
        {
            builder.Register<LevelStartState>(Lifetime.Singleton);
            builder.Register<LevelEndState>(Lifetime.Singleton);
        }

        private void RegisterStateFactories(IContainerBuilder builder)
        {
            builder.Register<LevelStartStateFactory>(Lifetime.Singleton);
            builder.RegisterFactory<IStateSwitcher, LevelStartState>(container => 
                container.Resolve<LevelStartStateFactory>().CreateState, Lifetime.Singleton);        

            builder.Register<LevelEndStateFactory>(Lifetime.Singleton);
            builder.RegisterFactory<LevelEndState>(container => 
                container.Resolve<LevelEndStateFactory>().CreateState, Lifetime.Singleton);
        }
    }
}