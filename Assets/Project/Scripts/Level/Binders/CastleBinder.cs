using Game.Level.Services.Castles;
using Game.Extra;
using Game.Level.Health;
using System;


namespace Game.Level.Binders
{
    public class CastleBinder
    {
        public event Action OnSystemEnabled;
        public event Action OnSystemDisabled;
        
        
        public readonly ReactiveProperty<IHealthParamsProvider> HealthView = new();

        private readonly CastleModel _castleModel;
        

        public CastleBinder(CastleModel castleModel)
        {
            _castleModel = castleModel;

            _castleModel.OnEnabled += Enable;
            _castleModel.OnDisabled += Disable;
        }
        
        
        private void Enable()
        {
            _castleModel.PhysicBody.OnHealthUpdate += UpdateHealth;
            
            OnSystemEnabled?.Invoke();
        }
				
        private void Disable()
        {
            _castleModel.PhysicBody.OnHealthUpdate -= UpdateHealth;
            
            OnSystemDisabled?.Invoke();
        }

        private void UpdateHealth(HealthParamsHandler healthParams)
            => HealthView.Value = healthParams;
    }
}