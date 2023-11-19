using Project.Scripts.Level.Weapons.HandlePoints.MVP;
using System.Collections.Generic;


namespace Project.Scripts.Level.Weapons.HandlePoints
{
    public class WeaponPointsContainer
    {
        private ISet<WeaponPointModel> _occupiedPoints;
        private ISet<WeaponPointModel> _emptyPoints;

        
        public IEnumerable<WeaponPointModel> OccupiedPoints => _occupiedPoints;
        public IEnumerable<WeaponPointModel> EmptyPoints => _emptyPoints;

        
        public void Init(IList<WeaponPointModel> weaponHandlePoints)
        {
            _occupiedPoints = new HashSet<WeaponPointModel>(weaponHandlePoints.Count);
            _emptyPoints = new HashSet<WeaponPointModel>(weaponHandlePoints);
        }
        
        public void RegisterPointAsOccupied(WeaponPointModel weaponHandlePoint)
        {
            _occupiedPoints.Add(weaponHandlePoint);
            _emptyPoints.Remove(weaponHandlePoint);
        }

        public void UnregisterPointAsOccupied(WeaponPointModel weaponHandlePoint)
        {
            _occupiedPoints.Remove(weaponHandlePoint);
            _emptyPoints.Add(weaponHandlePoint);
        }
    }
}