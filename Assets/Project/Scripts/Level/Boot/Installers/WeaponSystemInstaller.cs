using Project.Scripts.Level.Weapons;
using Project.Scripts.Level.Weapons.Creation;
using Project.Scripts.Level.Weapons.HandlePoints;
using Project.Scripts.Level.Weapons.Handling;
using Project.Scripts.Level.Weapons.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;


namespace Project.Scripts.Level.Boot.Installers
{
    public class WeaponSystemInstaller : IInstaller
    {
        private readonly Weapon _creationPrefab;
        private readonly Transform _weaponParent;
        private readonly WeaponSystemView _weaponSystemView;

        
        public WeaponSystemInstaller(Weapon prefab, Transform weaponParent, 
            WeaponSystemView weaponSystemView)
        {
            _weaponSystemView = weaponSystemView;
            _weaponParent = weaponParent;
            _creationPrefab = prefab;
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
            builder.Register<WeaponPointsContainer>(Lifetime.Scoped);
        }

        private static void RegisterWeaponDeleteService(IContainerBuilder builder)
        {
            builder.Register<WeaponDeletionService>(Lifetime.Scoped);
        }

        private static void RegisterWeaponUpdateService(IContainerBuilder builder)
        {
            builder.Register<WeaponUpdateService>(Lifetime.Scoped);
        }

        private void RegisterWeaponCreationService(IContainerBuilder builder)
        {
            builder
                .Register<WeaponCreateService>(Lifetime.Scoped)
                .WithParameter(_creationPrefab);

            builder
                .Register<WeaponFactory>(Lifetime.Scoped)
                .WithParameter(_weaponParent);
        }

        private void RegisterWeaponSystemView(IContainerBuilder builder)
        {
            builder.RegisterComponent(_weaponSystemView);
        }

        private void RegisterWeaponSystemBinder(IContainerBuilder builder)
        {
            builder.Register<WeaponSystemBinder>(Lifetime.Scoped);
        }

        private void RegisterWeaponHandleService(IContainerBuilder builder)
        {
            builder.Register<WeaponHandleService>(Lifetime.Scoped);
        }
    }
}