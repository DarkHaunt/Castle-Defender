using Game.Extra;
using Project.Scripts.Level.Common.Damage;
using System;


namespace Project.Scripts.Level.Castles
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