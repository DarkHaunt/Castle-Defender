

using System;


namespace Game.Level.Enemies
{
    public interface IEnemy
    {
        event Action<IEnemy> OnDeath;
        
        void PerformBehavior(float timeDelta);
        void EndBehavior();

        void Move(IAttackTarget attackTarget, float timeDelta);
        void Attack(IAttackTarget attackTarget);
        void Die(float timeDelta);
    }
}