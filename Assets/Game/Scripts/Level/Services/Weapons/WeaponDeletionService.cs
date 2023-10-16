

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
                occupiedPoint.EnableDeleteView(true);
        }
				
        public void EndHandleDelete() 
        {
            foreach (var occupiedPoint in _weaponPointsContainer.OccupiedPoints)
                occupiedPoint.EnableDeleteView(false);
        }
        
        private void DeleteWeaponAt(WeaponPointView weaponHandlePoint)
        {
            /*_weaponPointsContainer.UnregisterPointAsOccupied(weaponHandlePoint);
            weaponHandlePoint.DeleteWeapon();

            DisableDeletionFor(weaponHandlePoint);*/
        }

        private void EnableDeletionFor(WeaponPointView occupiedPoint)
        {
            /*occupiedPoint.OnDeleteButtonPressed += DeleteWeaponAt;
            occupiedPoint.EnableDeleteView();*/
        }

        private void DisableDeletionFor(WeaponPointView occupiedPoint)
        {
            /*occupiedPoint.OnDeleteButtonPressed -= DeleteWeaponAt;
            occupiedPoint.DisableDeleteView();*/
        }
    }
}