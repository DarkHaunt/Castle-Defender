using Game.Level.Common.Damage;
using Game.Level.Enemies;
using Game.Level.Castles;
using System;


namespace Game.Level.Services.Castles
{
    public class CastleService : ICastleService
    {
        public event Action OnDisabled;
        public event Action OnEnabled;

        public event Action<HealthParamsHandler> OnCastleHealthUpdated;
        public event Action OnCastleDestroyed;


        private IAttackTarget _castlePhysicsBody;


        public void Init(Castle castle, float castleMaxHealth)
        {
            _castlePhysicsBody = castle.PhysicBody;
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