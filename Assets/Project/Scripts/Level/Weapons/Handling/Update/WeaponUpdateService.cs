using Project.Scripts.Level.Weapons.HandlePoints;
using Project.Scripts.Level.Weapons.HandlePoints.MVP;


namespace Project.Scripts.Level.Weapons.Handling
{
    public class WeaponUpdateService
    {
        private readonly WeaponPointsContainer _weaponPointsContainer;
        

        public WeaponUpdateService(WeaponPointsContainer weaponPointsContainer)
        {
            _weaponPointsContainer = weaponPointsContainer;
        }
        

        public void StartHandleUpdate()
        {
            foreach (var occupiedPoint in _weaponPointsContainer.OccupiedPoints)
            {
                occupiedPoint.EnableUpdate(true);
                occupiedPoint.OnSelected += UpdateWeapon;
            }
        }
				
        public void EndHandleUpdate() 
        {
            foreach (var occupiedPoint in _weaponPointsContainer.OccupiedPoints)
            {
                occupiedPoint.EnableUpdate(false);
                occupiedPoint.OnSelected -= UpdateWeapon;
            }
        }
        
        private void UpdateWeapon(WeaponPointModel weaponPointModel)
        {
            weaponPointModel.UpdateWeapon();
        }
    }
}