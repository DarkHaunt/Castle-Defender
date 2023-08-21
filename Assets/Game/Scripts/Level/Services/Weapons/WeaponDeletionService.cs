

using Game.Level.Weapons.HandlePoints;


namespace Game.Level.Services.Weapons
{
    public class WeaponDeletionService
    {
        private readonly IWeaponPointsContainer _weaponPointsContainer;
        

        public WeaponDeletionService(IWeaponPointsContainer weaponPointsContainer)
        {
            _weaponPointsContainer = weaponPointsContainer;
        }
        
        
        public void StartHandleDelete()
        {
            foreach (var occupiedPoint in _weaponPointsContainer.OccupiedPoints)
                EnableDeletionFor(occupiedPoint);
        }
				
        public void EndHandleDelete() 
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