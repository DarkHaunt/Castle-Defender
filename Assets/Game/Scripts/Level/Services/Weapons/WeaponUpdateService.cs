using Game.Level.Weapons.HandlePoints;
using UnityEngine;


namespace Game.Level.Services.Weapons
{
    public class WeaponUpdateService
    {
        private readonly IWeaponPointsContainer _weaponPointsContainer;
        

        public WeaponUpdateService(IWeaponPointsContainer weaponPointsContainer)
        {
            _weaponPointsContainer = weaponPointsContainer;
        }
        

        public void Enable() 
        {
            foreach (var occupiedPoint in _weaponPointsContainer.OccupiedPoints)
                occupiedPoint.Enable();
        }
				
        public void Disable() 
        {
            foreach (var occupiedPoint in _weaponPointsContainer.OccupiedPoints)
                occupiedPoint.Disable();
        }
        
        public void StartHandleUpdate()
        {
            foreach (var occupiedPoint in _weaponPointsContainer.OccupiedPoints)
                EnableUpdateFor(occupiedPoint);
        }
				
        public void EndHandleUpdate() 
        {
            foreach (var occupiedPoint in _weaponPointsContainer.OccupiedPoints)
                DisableUpdateFor(occupiedPoint);
        }
        
        private void UpdateWeaponAt(WeaponHandlePoint weaponHandlePoint)
        {
            Debug.Log($"<color=yellow>Update kinda</color>");
        }

        private void EnableUpdateFor(WeaponHandlePoint occupiedPoint)
        {
            occupiedPoint.OnUpdateButtonPressed += UpdateWeaponAt;
            occupiedPoint.EnableUpdateView();
        }

        private void DisableUpdateFor(WeaponHandlePoint occupiedPoint)
        {
            occupiedPoint.OnUpdateButtonPressed -= UpdateWeaponAt;
            occupiedPoint.DisableUpdateView();
        }
    }
}