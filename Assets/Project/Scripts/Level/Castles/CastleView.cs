using Project.Scripts.Level.Common.Damage;
using UnityEngine;
using VContainer;


namespace Project.Scripts.Level.Castles
{
    public abstract class CastleView : MonoBehaviour
    {
        private CastleBinder _castleBinder;


        [Inject]
        private void Construct(CastleBinder castleBinder)
        {
            _castleBinder = castleBinder;

            _castleBinder.OnSystemEnabled += Enable;
            _castleBinder.OnSystemDisabled += Disable;
        }
        
        private void Enable()
        {
            _castleBinder.HealthView.OnChanged += UpdateHealthText;
            _castleBinder.HealthView.OnChanged += UpdateHealth;
            
            OnEnableCustom();
        }
				
        private void Disable() 
        {
            _castleBinder.HealthView.OnChanged -= UpdateHealthText;
            _castleBinder.HealthView.OnChanged -= UpdateHealth;
            
            OnDisableCustom();
        }

        protected abstract void UpdateHealthText(IHealthParamsProvider healthParams);
        protected abstract void UpdateHealth(IHealthParamsProvider healthParams);
        protected abstract void OnDisableCustom();
        protected abstract void OnEnableCustom();
    }
}