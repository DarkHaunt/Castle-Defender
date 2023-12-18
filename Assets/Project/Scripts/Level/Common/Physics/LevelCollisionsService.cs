using UnityEngine;


namespace Project.Scripts.Level.Common.Physics
{
    using static LevelLayersProvider;
    
    public class LevelCollisionsService
    {
        public void EnableCollisionsSettings() 
        {
            Physics2D.IgnoreLayerCollision(EnemiesLayer, EnemiesLayer, true);
            Physics2D.IgnoreLayerCollision(PlayerLayer, PlayerLayer, true);
            
            Physics2D.IgnoreLayerCollision(WeaponLayer, PlayerLayer, true);
            Physics2D.IgnoreLayerCollision(WeaponLayer, WeaponLayer, true);
        }
				
        public void DisableCollisionsSettings() 
        {
            Physics2D.IgnoreLayerCollision(EnemiesLayer, EnemiesLayer, false);
            Physics2D.IgnoreLayerCollision(PlayerLayer, PlayerLayer, false);
            
            Physics2D.IgnoreLayerCollision(WeaponLayer, PlayerLayer, false);
            Physics2D.IgnoreLayerCollision(WeaponLayer, WeaponLayer, false);
        }
    }
}