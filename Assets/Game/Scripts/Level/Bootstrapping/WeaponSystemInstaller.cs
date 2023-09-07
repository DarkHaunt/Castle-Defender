using Game.Level.Weapons.HandlePoints;
using Game.Level.Factories.Weapons;
using Game.Level.Services.Weapons;
using System.Collections.Generic;
using Game.Level.Views.Weapons;
using Game.Level.Binders;
using Game.Level.Weapons;
using VContainer.Unity;
using UnityEngine;
using VContainer;


namespace Game.Level.Installers
{
    public class WeaponSystemInstaller : IInstaller
    {
        private readonly Weapon _creationPrefab;
        private readonly Transform _weaponParent;
        private readonly WeaponSystemView _weaponSystemView;
        private readonly List<WeaponHandlePoint> _weaponPlacePoints;

        
        public WeaponSystemInstaller(Weapon prefab, Transform weaponParent, 
            WeaponSystemView weaponSystemView, List<WeaponHandlePoint> weaponHandlePoints)
        {
            _creationPrefab = prefab;
            _weaponParent = weaponParent;
            _weaponSystemView = weaponSystemView;
            _weaponPlacePoints = weaponHandlePoints;
        }
        
        
        public void Install(IContainerBuilder builder)
        {
            RegisterWeaponPointsContainer(builder);
            
            RegisterWeaponDeleteService(builder);
            RegisterWeaponUpdateService(builder);
            RegisterWeaponCreationService(builder);

            RegisterWeaponSystemView(builder);
            RegisterWeaponSystemBinder(builder);
            RegisterWeaponHandleService(builder);
        }

        private void RegisterWeaponPointsContainer(IContainerBuilder builder)
        {
            builder
                .Register<WeaponPointsContainer>(Lifetime.Singleton)
                .WithParameter(_weaponPlacePoints)
                .As<IWeaponPointsContainer>();
        }

        private static void RegisterWeaponDeleteService(IContainerBuilder builder)
        {
            builder.Register<WeaponDeletionService>(Lifetime.Singleton);
        }

        private static void RegisterWeaponUpdateService(IContainerBuilder builder)
        {
            builder.Register<WeaponUpdateService>(Lifetime.Singleton);
        }

        private void RegisterWeaponCreationService(IContainerBuilder builder)
        {
            builder
                .Register<WeaponCreateService>(Lifetime.Singleton)
                .WithParameter(_creationPrefab);

            builder
                .Register<WeaponFactory>(Lifetime.Singleton)
                .WithParameter(_weaponParent)
                .As<IWeaponFactory>();
        }

        private void RegisterWeaponSystemView(IContainerBuilder builder)
        {
            builder.RegisterComponent(_weaponSystemView);
        }

        private void RegisterWeaponSystemBinder(IContainerBuilder builder)
        {
            builder.Register<WeaponSystemBinder>(Lifetime.Singleton);
        }

        private void RegisterWeaponHandleService(IContainerBuilder builder)
        {
            builder
                .Register<WeaponHandleService>(Lifetime.Singleton)
                .As<IWeaponHandleService>();
        }
    }
}