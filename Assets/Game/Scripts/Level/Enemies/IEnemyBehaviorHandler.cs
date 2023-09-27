

using System;


namespace Game.Level.Enemies
{
    public interface IEnemyBehaviorHandler
    {
        event Action<IEnemyBehaviorHandler> OnDeath;
        
        void PerformBehavior(float timeDelta);
        void EndBehavior();

        void Move(IAttackTarget attackTarget, float timeDelta);
        void Attack(IAttackTarget attackTarget);
        void Die(float timeDelta);
    }
}