using Game.Level.Castles.Params;
using System;


namespace Game.Level.Castles
{
    public class Castle : ICastle
    {
        public event Action<HealthParamsHandler> OnHealthUpdate;
        public event Action<float> OnDamage;
        public event Action OnDeath;

        private readonly HealthParamsHandler _healthParamsHandler;

        
        public Castle(CastleParams castleParams)
        {
            _healthParamsHandler = new HealthParamsHandler(castleParams.Health);
        }

        
        public void GetDamage(float damage)
        {
            _healthParamsHandler.DecreaseHealthBy(damage);
            
            OnHealthUpdate?.Invoke(_healthParamsHandler);
            OnDamage?.Invoke(damage);
            
            if (_healthParamsHandler.IsCurrentHealthZero())
                OnDeath?.Invoke();
        }
    }
}