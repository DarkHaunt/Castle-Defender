using Project.Scripts.Level.Weapons.HandlePoints.MVP;
using System.Collections.Generic;


namespace Project.Scripts.Level.Weapons.HandlePoints
{
    public interface IWeaponPointsContainer
    {
        IEnumerable<WeaponPointModel> EmptyPoints { get; }
        IEnumerable<WeaponPointModel> OccupiedPoints { get; }


        void Init(IList<WeaponPointModel> weaponHandlePoints);
        void RegisterPointAsOccupied(WeaponPointModel weaponHandlePoint);
        void UnregisterPointAsOccupied(WeaponPointModel weaponHandlePoint);
    }
}