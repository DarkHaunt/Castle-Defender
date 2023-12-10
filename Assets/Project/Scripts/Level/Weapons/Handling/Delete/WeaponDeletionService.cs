using Project.Scripts.Level.Weapons.Handling.WeaponPoints;
using Project.Scripts.Level.Weapons.Handling.WeaponPoints.MVP;


namespace Project.Scripts.Level.Weapons.Handling.Delete
{
    public class WeaponDeletionService
    {
        private readonly WeaponPointsContainer _weaponPointsContainer;
        

        public WeaponDeletionService(WeaponPointsContainer weaponPointsContainer)
        {
            _weaponPointsContainer = weaponPointsContainer;
        }
        
        
        public void StartHandleDelete()
        {
            foreach (var occupiedPoint in _weaponPointsContainer.OccupiedPoints)
                EnableDeleteFor(occupiedPoint);
        }

        public void EndHandleDelete() 
        {
            foreach (var occupiedPoint in _weaponPointsContainer.OccupiedPoints)
                DisableDeleteFor(occupiedPoint);
        }

        private void EnableDeleteFor(WeaponPointModel occupiedPoint)
        {
            occupiedPoint.EnableDelete(true);
            occupiedPoint.OnSelected += DeleteWeaponAt;
        }

        private void DisableDeleteFor(WeaponPointModel occupiedPoint)
        {
            occupiedPoint.EnableDelete(false);
            occupiedPoint.OnSelected -= DeleteWeaponAt;
        }

        private void DeleteWeaponAt(WeaponPointModel weaponPointModel)
        {
            _weaponPointsContainer.UnregisterPointAsOccupied(weaponPointModel);
            weaponPointModel.DeleteWeapon();
            
            DisableDeleteFor(weaponPointModel);
        }
    }
}