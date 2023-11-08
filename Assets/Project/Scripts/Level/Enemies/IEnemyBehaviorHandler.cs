using System;


namespace Project.Scripts.Level.Enemies
{
    public interface IEnemyBehaviorHandler
    {
        event Action<Enemy> OnBehaviorHandlingEnded;
        
        void PerformBehavior(float timeDelta);
        void EndBehavior();
    }
}