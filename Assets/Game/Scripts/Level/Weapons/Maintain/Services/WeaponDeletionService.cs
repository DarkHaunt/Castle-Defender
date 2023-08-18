

namespace Game.Level.Weapons.Maintain.Services
{
    public class WeaponDeletionService
    {
        private readonly IWeaponPointsContainer _weaponPointsContainer;
        

        public WeaponDeletionService(IWeaponPointsContainer weaponPointsContainer)
        {
            _weaponPointsContainer = weaponPointsContainer;
        }
        
        
        public void StartHandleDeletion()
        {
            foreach (var occupiedPoint in _weaponPointsContainer.OccupiedPoints)
                EnableDeletionFor(occupiedPoint);
        }
				
        public void EndHandleDeletion() 
        {
            foreach (var occupiedPoint in _weaponPointsContainer.OccupiedPoints)
                DisableDeletionFor(occupiedPoint);
        }
        
        private void DeleteWeaponAt(WeaponHandlePoint weaponHandlePoint)
        {
            _weaponPointsContainer.UnregisterPointAsOccupied(weaponHandlePoint);
            weaponHandlePoint.DeleteWeapon();

            DisableDeletionFor(weaponHandlePoint);
        }

        private void EnableDeletionFor(WeaponHandlePoint occupiedPoint)
        {
            occupiedPoint.OnDeleteButtonPressed += DeleteWeaponAt;
            occupiedPoint.EnableDeleteView();
        }

        private void DisableDeletionFor(WeaponHandlePoint occupiedPoint)
        {
            occupiedPoint.OnDeleteButtonPressed -= DeleteWeaponAt;
            occupiedPoint.DisableDeleteView();
        }
    }
}