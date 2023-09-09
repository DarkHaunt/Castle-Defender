﻿using System.Collections.Generic;


namespace Game.Level.Weapons.HandlePoints
{
    public class WeaponPointsContainer : IWeaponPointsContainer
    {
        private ISet<WeaponHandlePoint> _occupiedPoints;
        private ISet<WeaponHandlePoint> _emptyPoints;

        
        public IEnumerable<WeaponHandlePoint> OccupiedPoints => _occupiedPoints;
        public IEnumerable<WeaponHandlePoint> EmptyPoints => _emptyPoints;

        
        public void Init(List<WeaponHandlePoint> weaponHandlePoints)
        {
            _occupiedPoints = new HashSet<WeaponHandlePoint>(weaponHandlePoints.Capacity);
            _emptyPoints = new HashSet<WeaponHandlePoint>(weaponHandlePoints);
        }
        
        public void RegisterPointAsOccupied(WeaponHandlePoint weaponHandlePoint)
        {
            _occupiedPoints.Add(weaponHandlePoint);
            _emptyPoints.Remove(weaponHandlePoint);
        }

        public void UnregisterPointAsOccupied(WeaponHandlePoint weaponHandlePoint)
        {
            _occupiedPoints.Remove(weaponHandlePoint);
            _emptyPoints.Add(weaponHandlePoint);
        }
    }
}