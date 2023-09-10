using Game.Level.Common.Lifecycle;
using Game.Level.Common.Damage;
using Game.Level.Enemies;
using System;


namespace Game.Level.Services.Castles
{ 
    public interface ICastleHandleService : IEnableable
    {
        event Action<HealthParamsHandler> OnCastleHealthUpdated;
        event Action OnCastleDestroyed;
        event Action OnDisabled;
        event Action OnEnabled;

        void Init(IAttackTarget castlePhysicsBody, float castleMaxHealth);
    }
}