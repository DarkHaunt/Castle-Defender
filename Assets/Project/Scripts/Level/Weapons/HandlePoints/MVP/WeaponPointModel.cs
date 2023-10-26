using System;
using UnityEngine;
using Object = UnityEngine.Object;


namespace Game.Level.Weapons.HandlePoints.MVP
{
    public class WeaponPointModel
    {
        public event Action<WeaponPointModel> OnSelected;
        public event Action<bool> OnRegisterEnabled;
        public event Action<bool> OnDeleteEnabled;
        public event Action<bool> OnUpdateEnabled;
        
        
        public Vector2 Position { get; }
        
        private Weapon _weapon;

        
        public WeaponPointModel(Vector2 position)
        {
            Position = position;
        }


        public void EnableRegister(bool enable)
            => OnRegisterEnabled?.Invoke(enable);
        public void EnableDelete(bool enable)
            => OnDeleteEnabled?.Invoke(enable);
        public void EnableUpdate(bool enable)
            => OnUpdateEnabled?.Invoke(enable);
        public void NotifySelected()
            => OnSelected?.Invoke(this);


        public void RegisterWeapon(Weapon weapon)
        {
            _weapon = weapon;
        }

        public void UpdateWeapon()
        {
            Debug.Log($"<color=yellow>UPDATE WEAPON KINDA</color>");
        }

        public void DeleteWeapon()
        {
            Object.Destroy(_weapon.gameObject);
        }
    }
}