using System.Collections.Generic;


namespace Game.Level.Weapons.Maintain
{
    public interface IWeaponsContainer
    {
        void RegisterWeapon(Weapon weapon);
        void UnregisterWeapon(Weapon weapon);

        IEnumerable<Weapon> GetAllRegisteredWeapons();
    }
}