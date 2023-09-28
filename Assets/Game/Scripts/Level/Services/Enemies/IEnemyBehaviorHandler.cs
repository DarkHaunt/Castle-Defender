using System;


namespace Game.Level.Enemies
{
    public interface IEnemyBehaviorHandler
    {
        event Action<IEnemyBehaviorHandler> OnBehaviorHandlingEnded;
        
        void PerformBehavior(float timeDelta);
        void EndBehavior();
    }
}