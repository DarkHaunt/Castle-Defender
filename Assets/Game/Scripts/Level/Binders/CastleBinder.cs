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

        private readonly ICastleService _castleService;
        

        public CastleBinder(ICastleService castleService)
        {
            _castleService = castleService;

            _castleService.OnEnabled += Enable;
            _castleService.OnDisabled += Disable;
        }
        
        
        private void Enable()
        {
            _castleService.OnCastleHealthUpdated += UpdateHealth;
            
            OnSystemEnabled?.Invoke();
        }
				
        private void Disable()
        {
            _castleService.OnCastleHealthUpdated -= UpdateHealth;
            
            OnSystemDisabled?.Invoke();
        }

        private void UpdateHealth(HealthParamsHandler healthParams)
        {
            HealthView.Value = healthParams;
        }
    }
}