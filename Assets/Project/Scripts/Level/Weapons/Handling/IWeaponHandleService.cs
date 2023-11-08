using Game.Common.Interfaces;
using System;


namespace Project.Scripts.Level.Weapons.Handling
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