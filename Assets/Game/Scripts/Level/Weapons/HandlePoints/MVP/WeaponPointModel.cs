using UnityEngine;


namespace Game.Level.Weapons.HandlePoints.MVP
{
    public class WeaponPointModel
    {
        private Weapon _weapon;

        public Vector2 Position 
            => _weapon.transform.position;


        public void RegisterWeapon(Weapon weapon)
            => _weapon = weapon;
        
        public void EnableWeapon()
            => _weapon.Enable();

        public void DisableWeapon()
            => _weapon.Disable();

        public void Update()
            => Debug.Log($"<color=yellow>UPDATE WEAPON KINDA</color>");

        public void DeleteWeapon()
            => Object.Destroy(_weapon.gameObject);
    }
}