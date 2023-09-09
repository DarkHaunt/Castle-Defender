using Game.Level.Castles;
using Game.Level.Common.Damage;
using System;


namespace Game.Level.Services.Castles
{ 
    public interface ICastleService
    {
        event Action OnDisabled;
        event Action OnEnabled;
        
        event Action<HealthParamsHandler> OnCastleHealthUpdated;
        event Action OnCastleDestroyed;


        void Init(Castle castle, float castleMaxHealth);
        void Enable(); 
        void Disable();
    }
}