﻿using System.Collections.Generic;


namespace Game.Level.Weapons.HandlePoints
{
    public interface IWeaponPointsContainer
    {
        IEnumerable<WeaponHandlePoint> EmptyPoints { get; }
        IEnumerable<WeaponHandlePoint> OccupiedPoints { get; }


        void Init(List<WeaponHandlePoint> weaponHandlePoints);
        void RegisterPointAsOccupied(WeaponHandlePoint weaponHandlePoint);
        void UnregisterPointAsOccupied(WeaponHandlePoint weaponHandlePoint);
    }
}