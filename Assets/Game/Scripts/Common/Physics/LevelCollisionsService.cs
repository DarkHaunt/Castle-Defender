using UnityEngine;


namespace Game.Common.Physics
{
    public class LevelCollisionsService
    {
        private const int EnemiesLayer = 6;
        
        
        public void EnableCollisionsSettings() 
        {
            Physics2D.IgnoreLayerCollision(EnemiesLayer, EnemiesLayer, true);
        }
				
        public void DisableCollisionsSettings() 
        {
            Physics2D.IgnoreLayerCollision(EnemiesLayer, EnemiesLayer, false);
        }
    }
}