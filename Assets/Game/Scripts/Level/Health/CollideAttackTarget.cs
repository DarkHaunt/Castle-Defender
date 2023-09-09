using Game.Level.Enemies;
using UnityEngine;
using System;


namespace Game.Level.Common.Damage
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Collider2D))]
    public class CollideAttackTarget : MonoBehaviour, IAttackTarget
    {
        public event Action<HealthParamsHandler> OnHealthUpdate;
        public event Action<float> OnDamage;
        public event Action OnDeath;

        private Transform _transform;
        private HealthParamsHandler _healthParams;

        
        public Vector2 Position
            => _transform.position;
        
        
        private void OnValidate()
        {
            var self = GetComponent<Collider2D>();
            self.isTrigger = false;
        }

        public void Init(float maxHealth)
        {
            _transform = GetComponent<Transform>();

            _healthParams = new HealthParamsHandler
            (
                initHealth: maxHealth
            );
            
            OnHealthUpdate?.Invoke(_healthParams);
        }

        public void GetDamage(float damage)
        {
            _healthParams.DecreaseHealthBy(damage);
            
            OnDamage?.Invoke(damage);
            OnHealthUpdate?.Invoke(_healthParams);
            
            if (_healthParams.IsCurrentHealthZero())
                OnDeath?.Invoke();
        }
    }
}