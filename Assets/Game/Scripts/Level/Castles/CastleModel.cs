using System;
using Game.Extensions;
using Game.Level.Common.Damage;
using Game.Level.Common.Lifecycle;
using Game.Level.Common.Triggers;
using UnityEngine;


namespace Game.Level.Castles
{
    public class CastleModel : ICastle, IEnableable
    {
        public event Action OnDamage;
        public event Action OnDeath; 
        

        private readonly ICollisionObserver _castleCollision;

        private float _health;

        
        public CastleModel(ICollisionObserver castleCollision, float initHealth)
        {
            _castleCollision = castleCollision;
            _health = initHealth;
        }

        public void Enable()
            => _castleCollision.OnCollideEnter += ProcessCollisionEnter;

        public void Disable()
            => _castleCollision.OnCollideExit -= ProcessCollisionEnter;

        private void ProcessCollisionEnter(Collision2D collision2D)
        {
            if (!collision2D.collider.TryGetComponent(out IAttackHandler attackHandler))
                return;

            attackHandler.Attack(this);
        }

        public void GetDamage(float damage)
        {
            _health -= MathfExtensions.PositiveClamp(_health);
            OnDamage?.Invoke();
            
            if (Mathf.Approximately(_health, 0))
                OnDeath?.Invoke();
        }
    }
}