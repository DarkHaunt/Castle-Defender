using Game.Extra;
using Game.Level.Common.Damage;
using Game.Level.Services.Castles;


namespace Game.Level.Binders
{
    public class CastleBinder
    {
        public readonly ReactiveProperty<IHealthParamsProvider> HealthView = new();

        private readonly ICastle _castle;
        

        public CastleBinder(ICastle castle)
        {
            _castle = castle;
        }
        
        
        public void Enable()
        {
            _castle.OnHealthUpdate += UpdateHealth;
        }
				
        public void Disable()
        {
            _castle.OnHealthUpdate -= UpdateHealth;
        }

        private void UpdateHealth(HealthParamsHandler healthParams)
        {
            HealthView.Value = healthParams;
        }
    }
}