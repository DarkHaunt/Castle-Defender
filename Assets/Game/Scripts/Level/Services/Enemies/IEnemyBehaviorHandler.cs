using System;


namespace Game.Level.Enemies
{
    public interface IEnemyBehaviorHandler
    {
        event Action<Enemy> OnBehaviorHandlingEnded;
        
        void PerformBehavior(float timeDelta);
        void EndBehavior();
    }
}