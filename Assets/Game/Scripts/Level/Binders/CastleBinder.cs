using Game.Level.Services.Castles;
using Game.Level.Common.Damage;
using Game.Extra;


namespace Game.Level.Binders
{
    public class CastleBinder
    {
        public readonly ReactiveProperty<IHealthParamsProvider> HealthView = new();

        private readonly ICastleService _castleService;
        

        public CastleBinder(ICastleService castleService)
        {
            _castleService = castleService;
        }
        
        
        public void Enable()
        {
            _castleService.OnCastleHealthUpdated += UpdateHealth;
        }
				
        public void Disable()
        {
            _castleService.OnCastleHealthUpdated -= UpdateHealth;
        }

        private void UpdateHealth(HealthParamsHandler healthParams)
        {
            HealthView.Value = healthParams;
        }
    }
}