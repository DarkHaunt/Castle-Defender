using Game.Level.Common.Lifecycle;
using System;


namespace Game.Level.Services.Weapons
{
    public interface IWeaponHandleService : IEnableable
    {
        event Action OnEnabled;
        event Action OnDisabled;
        
        void StartHandleCreate();
        void StartHandleUpdate();
        void StartHandleDelete();  
        
        void EndHandleCreate();
        void EndHandleUpdate();
        void EndHandleDelete();
    }
}