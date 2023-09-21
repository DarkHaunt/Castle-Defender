using Game.Level.Services.Castles;
using Game.Level.Common.Damage;
using Game.Extra;
using System;


namespace Game.Level.Binders
{
    public class CastleBinder
    {
        public event Action OnSystemEnabled;
        public event Action OnSystemDisabled;
        
        
        public readonly ReactiveProperty<IHealthParamsProvider> HealthView = new();

        private readonly CastleHandleService _castleHandleService;
        

        public CastleBinder(CastleHandleService castleHandleService)
        {
            _castleHandleService = castleHandleService;

            _castleHandleService.OnEnabled += Enable;
            _castleHandleService.OnDisabled += Disable;
        }
        
        
        private void Enable()
        {
            _castleHandleService.OnCastleHealthUpdated += UpdateHealth;
            
            OnSystemEnabled?.Invoke();
        }
				
        private void Disable()
        {
            _castleHandleService.OnCastleHealthUpdated -= UpdateHealth;
            
            OnSystemDisabled?.Invoke();
        }

        private void UpdateHealth(HealthParamsHandler healthParams)
        {
            HealthView.Value = healthParams;
        }
    }
}