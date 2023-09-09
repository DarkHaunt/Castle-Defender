using Game.Level.Common.Damage;
using Game.Level.Enemies;
using Game.Level.Castles;
using System;


namespace Game.Level.Services.Castles
{
    public class CastleService : ICastleService
    {
        public event Action<HealthParamsHandler> OnCastleHealthUpdated;
        public event Action OnCastleDestroyed;
        
        
        private IAttackTarget _castlePhysicsBody;


        public void Init(Castle castle)
        {
            _castlePhysicsBody = castle.PhysicBody;
        }

        public void Enable()
        {
            _castlePhysicsBody.OnDeath += NotifyCastleDestroyed;
            _castlePhysicsBody.OnHealthUpdate += NotifyCastleHealthUpdated;
        }

        public void Disable()
        {
            _castlePhysicsBody.OnDeath -= NotifyCastleDestroyed;
            _castlePhysicsBody.OnHealthUpdate -= NotifyCastleHealthUpdated;
        }
        
        
        private void NotifyCastleDestroyed()
            => OnCastleDestroyed?.Invoke();      
        
        private void NotifyCastleHealthUpdated(HealthParamsHandler currentHealth)
            => OnCastleHealthUpdated?.Invoke(currentHealth); 
    }
}