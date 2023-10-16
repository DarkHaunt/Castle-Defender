using System;
using UnityEngine;


namespace Game.Level.Weapons.HandlePoints.MVP
{
    public class WeaponPointPresenter
    {
        public event Action<WeaponPointPresenter> OnCreateWeapon;
        public event Action<WeaponPointPresenter> OnUpdateWeapon;
        public event Action<WeaponPointPresenter> OnDeleteWeapon;
        
        private readonly WeaponPointModel _weaponPointModel;
        private readonly WeaponPointView _weaponPointView;

        
        public WeaponPointPresenter(WeaponPointModel weaponPointModel, WeaponPointView weaponPointView)
        {
            _weaponPointModel = weaponPointModel;
            _weaponPointView = weaponPointView;

            _weaponPointView.OnUpdateButtonPressed += NotifyUpdateButtonPressed;
            _weaponPointView.OnCreateButtonPressed += NotifyCreateButtonPressed;
            _weaponPointView.OnDeleteButtonPressed += NotifyDeleteButtonPressed;
        }

        public Vector2 Position
            => _weaponPointModel.Position;
        
        
        public void EnableCreateView(bool enable)
            => _weaponPointView.EnableCreateView(enable);    
        public void EnableDeleteView(bool enable)
            => _weaponPointView.EnableDeleteView(enable);   
        public void EnableUpdateView(bool enable)
            => _weaponPointView.EnableUpdateView(enable);


        public void RegisterWeapon(Weapon weapon)
        {
            _weaponPointModel.RegisterWeapon(weapon);
            _weaponPointView.EnableCreateView(false);
        }

        public void UpdateRegisteredWeapon()
        {
            _weaponPointModel.Update();
            _weaponPointView.EnableUpdateView(false);
        }

        public void DeleteRegisteredWeapon()
        {
            _weaponPointModel.DeleteWeapon();
            _weaponPointView.EnableDeleteView(false);
        }
        
        
        private void NotifyCreateButtonPressed()
            => OnCreateWeapon?.Invoke(this);
        private void NotifyDeleteButtonPressed()
            => OnDeleteWeapon?.Invoke(this);
        private void NotifyUpdateButtonPressed()
            => OnUpdateWeapon?.Invoke(this);
    }
}