using Project.Scripts.Level.Weapons.Handling.WeaponPoints;
using Project.Scripts.Level.Weapons.Handling.Create;
using Project.Scripts.Level.Weapons.Handling.Delete;
using Project.Scripts.Level.Weapons.Handling.Update;
using Project.Scripts.Level.Weapons.Handling;
using Project.Scripts.Level.Weapons.View;
using Project.Scripts.Level.Init;
using VContainer.Unity;
using UnityEngine;
using VContainer;


namespace Project.Scripts.Level.Boot.Installers
{
    public class WeaponSystemInstaller : IInstaller
    {
        private readonly WeaponSystemView _weaponSystemView;
        private readonly Transform _weaponParent;
        
        public WeaponSystemInstaller(WeaponSystemView weaponSystemView, Transform weaponParent)
        {
            _weaponSystemView = weaponSystemView;
            _weaponParent = weaponParent;
        }
        
        
        public void Install(IContainerBuilder builder)
        {
            RegisterWeaponProvider(builder);
            
            RegisterWeaponDeleteService(builder);
            RegisterWeaponUpdateService(builder);
            RegisterWeaponCreationService(builder);

            RegisterWeaponSystemView(builder);
            RegisterWeaponSystemBinder(builder);
            RegisterWeaponHandleService(builder);
        }

        private void RegisterWeaponProvider(IContainerBuilder builder)
        {
            builder.Register<WeaponProvider>(Lifetime.Scoped);
        }

        private void RegisterWeaponCreationService(IContainerBuilder builder)
        {
            builder.Register<WeaponPointsContainer>(Lifetime.Scoped);
            
            builder.Register<WeaponChoseService>(Lifetime.Scoped)
                .WithParameter(_weaponSystemView.PickButtons);

            builder
                .Register<WeaponFactory>(Lifetime.Scoped)
                .WithParameter(_weaponParent);
            
            builder.Register<WeaponCreateService>(Lifetime.Scoped);
        }

        private void RegisterWeaponUpdateService(IContainerBuilder builder)
        {
            builder.Register<WeaponUpdateService>(Lifetime.Scoped);
        }

        private void RegisterWeaponDeleteService(IContainerBuilder builder)
        {
            builder.Register<WeaponDeletionService>(Lifetime.Scoped);
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