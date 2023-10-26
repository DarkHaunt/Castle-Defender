using UnityEngine;


namespace Game.Level.Common.Physics
{
    using static LevelLayersProvider;
    
    public class LevelCollisionsService
    {
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