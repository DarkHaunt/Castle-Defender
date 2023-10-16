using Game.Level.Weapons.HandlePoints.MVP;
using System.Collections.Generic;


namespace Game.Level.Weapons.HandlePoints
{
    public class WeaponPointsContainer : IWeaponPointsContainer
    {
        private ISet<WeaponPointPresenter> _occupiedPoints;
        private ISet<WeaponPointPresenter> _emptyPoints;

        
        public IEnumerable<WeaponPointPresenter> OccupiedPoints => _occupiedPoints;
        public IEnumerable<WeaponPointPresenter> EmptyPoints => _emptyPoints;

        
        public void Init(List<WeaponPointPresenter> weaponHandlePoints)
        {
            _occupiedPoints = new HashSet<WeaponPointPresenter>(weaponHandlePoints.Capacity);
            _emptyPoints = new HashSet<WeaponPointPresenter>(weaponHandlePoints);
        }
        
        public void RegisterPointAsOccupied(WeaponPointPresenter weaponHandlePoint)
        {
            _occupiedPoints.Add(weaponHandlePoint);
            _emptyPoints.Remove(weaponHandlePoint);
        }

        public void UnregisterPointAsOccupied(WeaponPointPresenter weaponHandlePoint)
        {
            _occupiedPoints.Remove(weaponHandlePoint);
            _emptyPoints.Add(weaponHandlePoint);
        }
    }
}