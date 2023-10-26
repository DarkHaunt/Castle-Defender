using Game.Level.Weapons.HandlePoints.MVP;
using Game.Level.Weapons.HandlePoints;


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