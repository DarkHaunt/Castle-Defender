using System.Collections.Generic;


namespace Game.Level.Weapons.Maintain
{
    public interface IWeaponPointsContainer
    {
        IEnumerable<WeaponHandlePoint> EmptyPoints { get; }
        IEnumerable<WeaponHandlePoint> OccupiedPoints { get; }
        
        void RegisterPointAsOccupied(WeaponHandlePoint weaponHandlePoint);
        void UnregisterPointAsOccupied(WeaponHandlePoint weaponHandlePoint);
    }
}