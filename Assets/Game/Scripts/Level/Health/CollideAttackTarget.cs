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

        private HealthParamsHandler _healthParams;
        private Collider2D _collider2D;
        private Transform _transform;


        public Vector2 Position
            => _transform.position;


        private void OnValidate()
        {
            var self = GetComponent<Collider2D>();
            self.isTrigger = false;
        }

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _collider2D = GetComponent<Collider2D>();
        }

        public void Init(float maxHealth)
        {
            _healthParams = new HealthParamsHandler(maxHealth);

            UpdateHealth();
        }

        public void Enable()
            => _collider2D.enabled = true;
				
        public void Disable() 
            => _collider2D.enabled = false;

        public void GetDamage(float damage)
        {
            _healthParams.DecreaseHealthBy(damage);
            
            OnDamage?.Invoke(damage);
            UpdateHealth();

            if (_healthParams.IsCurrentHealthZero())
                OnDeath?.Invoke();
        }

        public void UpdateHealth()
            => OnHealthUpdate?.Invoke(_healthParams);
    }
}