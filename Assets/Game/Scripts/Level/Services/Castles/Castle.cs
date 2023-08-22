using Game.Level.Params.Castles;
using Game.Level.Common.Damage;
using System;


namespace Game.Level.Services.Castles
{
    public class Castle : ICastle
    {
        public event Action<HealthParamsHandler> OnHealthUpdate;
        public event Action<float> OnDamage;
        public event Action OnDeath;

        
        private readonly HealthParamsHandler _healthParamsHandler;

        
        public Castle(ICastleParamsProvider paramsProvider)
        {
            var castleParams = paramsProvider.GetCastleParams();
            
            _healthParamsHandler = new HealthParamsHandler(castleParams.Health);
        }


        public void Enable()
        {
            UpdateHealthInvoke();
        }

        public void Disable()
        {
        }

        public void GetDamage(float damage)
        {
            _healthParamsHandler.DecreaseHealthBy(damage);
            OnDamage?.Invoke(damage);
            
            UpdateHealthInvoke();
            
            if (_healthParamsHandler.IsCurrentHealthZero())
                OnDeath?.Invoke();
        }

        private void UpdateHealthInvoke()
        {
            OnHealthUpdate?.Invoke(_healthParamsHandler);
        }
    }
}