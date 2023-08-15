using System.Collections.Generic;


namespace Game.Level.Weapons.Maintain
{
    public class WeaponsContainer : IWeaponsContainer
    {
        private readonly ISet<Weapon> _weapons = new HashSet<Weapon>();


        public IEnumerable<Weapon> GetAllRegisteredWeapons()
            => _weapons;
        
        public void RegisterWeapon(Weapon weapon)
            => _weapons.Add(weapon);

        public void UnregisterWeapon(Weapon weapon)
            => _weapons.Remove(weapon);
    }
}