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
        

        public void StartHandleUpdate()
        {
            foreach (var occupiedPoint in _weaponPointsContainer.OccupiedPoints)
                occupiedPoint.EnableUpdateView(true);
        }
				
        public void EndHandleUpdate() 
        {
            foreach (var occupiedPoint in _weaponPointsContainer.OccupiedPoints)
                occupiedPoint.EnableUpdateView(false);
        }
        
        private void UpdateWeaponAt(WeaponPointView weaponHandlePoint)
        {
            Debug.Log($"<color=yellow>Update kinda</color>");
        }

        private void EnableUpdateFor(WeaponPointView occupiedPoint)
        {
            /*occupiedPoint.OnUpdateButtonPressed += UpdateWeaponAt;
            occupiedPoint.EnableUpdateView();*/
        }

        private void DisableUpdateFor(WeaponPointView occupiedPoint)
        {
            /*occupiedPoint.OnUpdateButtonPressed -= UpdateWeaponAt;
            occupiedPoint.DisableUpdateView();*/
        }
    }
}