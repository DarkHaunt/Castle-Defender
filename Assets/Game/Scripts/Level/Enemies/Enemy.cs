using Game.Level.Common.Damage;
using System;
using UnityEngine;


namespace Game.Level.Enemies
{
    public abstract class Enemy : MonoBehaviour, IEnemy
    {
        public event Action<HealthParamsHandler> OnHealthUpdate;
        public event Action<float> OnDamage;
        public event Action OnDeath;

        [SerializeField] private float _health;

        private HealthParamsHandler _healthParamsHandler;


        public abstract void FollowTarget(IAttackTarget attackTarget);
        protected abstract void Attack(IAttackTarget attackTarget);
        
        
        public void Init()
            => _healthParamsHandler = new HealthParamsHandler(_health);

        public void GetDamage(float damage)
        {
            _healthParamsHandler.DecreaseHealthBy(damage);
            
            OnDamage?.Invoke(damage);
            OnHealthUpdate?.Invoke(_healthParamsHandler);
            
            if (_healthParamsHandler.IsCurrentHealthZero())
                OnDeath?.Invoke();
        }
    }
}