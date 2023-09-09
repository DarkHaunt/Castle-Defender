using Game.Level.Castles;
using Game.Level.Common.Damage;
using System;


namespace Game.Level.Services.Castles
{ 
    public interface ICastleService
    {
        event Action<HealthParamsHandler> OnCastleHealthUpdated;
        event Action OnCastleDestroyed;


        void Init(Castle castle);
        void Enable(); 
        void Disable();
    }
}