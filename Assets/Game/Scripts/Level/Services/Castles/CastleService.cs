﻿using Game.Level.Params.Castles;
using Game.Level.Common.Damage;
using Game.Level.Enemies;
using System;


namespace Game.Level.Services.Castles
{
    public class CastleService : ICastleService
    {
        public event Action<HealthParamsHandler> OnCastleHealthUpdated;
        public event Action OnCastleDestroyed;
        
        
        private readonly IAttackTarget _castlePhysicsBody;


        public CastleService(ICastleParamsProvider paramsProvider)
        {
            var castleParams = paramsProvider.GetCastleParams();

            _castlePhysicsBody = castleParams.PhysicBody;
            _castlePhysicsBody.Init(castleParams.Health);
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