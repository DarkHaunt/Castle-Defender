using Game.Level.Common.Damage;
using Game.Level.Enemies;
using System;


namespace Game.Level.Services.Castles
{
    public class CastleHandleService
    {
        public event Action<HealthParamsHandler> OnCastleHealthUpdated;
        public event Action OnCastleDestroyed;
        public event Action OnDisabled;
        public event Action OnEnabled;


        private IAttackTarget _castlePhysicsBody;


        public void Init(IAttackTarget castlePhysicsBody, float castleMaxHealth)
        {
            _castlePhysicsBody = castlePhysicsBody;
            _castlePhysicsBody.Init(castleMaxHealth);
        }

        public void Enable()
        {
            OnEnabled?.Invoke();
            
            _castlePhysicsBody.OnDeath += NotifyCastleDestroyed;
            _castlePhysicsBody.OnHealthUpdate += NotifyCastleHealthUpdated;
            
            _castlePhysicsBody.UpdateHealth();
        }

        public void Disable()
        {
            OnDisabled?.Invoke();

            _castlePhysicsBody.OnDeath -= NotifyCastleDestroyed;
            _castlePhysicsBody.OnHealthUpdate -= NotifyCastleHealthUpdated;
        }


        private void NotifyCastleDestroyed()
            => OnCastleDestroyed?.Invoke();

        private void NotifyCastleHealthUpdated(HealthParamsHandler currentHealth)
            => OnCastleHealthUpdated?.Invoke(currentHealth);
    }
}