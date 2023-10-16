using Game.Level.Weapons.HandlePoints.MVP;
using System.Collections.Generic;


namespace Game.Level.Weapons.HandlePoints
{
    public interface IWeaponPointsContainer
    {
        IEnumerable<WeaponPointPresenter> EmptyPoints { get; }
        IEnumerable<WeaponPointPresenter> OccupiedPoints { get; }


        void Init(List<WeaponPointPresenter> weaponHandlePoints);
        void RegisterPointAsOccupied(WeaponPointPresenter weaponHandlePoint);
        void UnregisterPointAsOccupied(WeaponPointPresenter weaponHandlePoint);
    }
}