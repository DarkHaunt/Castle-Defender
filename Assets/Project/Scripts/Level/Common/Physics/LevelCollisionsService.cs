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
        }
				
        public void DisableCollisionsSettings() 
        {
            Physics2D.IgnoreLayerCollision(EnemiesLayer, EnemiesLayer, false);
            Physics2D.IgnoreLayerCollision(PlayerLayer, PlayerLayer, false);
        }
    }
}