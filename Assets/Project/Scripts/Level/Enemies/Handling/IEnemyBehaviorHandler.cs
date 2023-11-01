using Game.Level.Enemies;
using System;


namespace Game.Level.Services.Enemies
{
    public interface IEnemyBehaviorHandler
    {
        event Action<Enemy> OnBehaviorHandlingEnded;
        
        void PerformBehavior(float timeDelta);
        void EndBehavior();
    }
}