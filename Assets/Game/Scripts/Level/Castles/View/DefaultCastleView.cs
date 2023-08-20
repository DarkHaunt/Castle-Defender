using Game.Level.Common.Damage;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


namespace Game.Level.Castles
{
    public class DefaultCastleView : CastleView
    {
        [Header("--- GUI View ---")]
        [SerializeField] private Slider _healthBar;
        [SerializeField] private TextMeshPro _healthText;


        public override void Enable()
        {
            _castleBinder.HealthView.OnChanged += UpdateHealthText;
            _castleBinder.HealthView.OnChanged += UpdateSlider;
        }

        public override void Disable()
        {
            _castleBinder.HealthView.OnChanged -= UpdateHealthText;
            _castleBinder.HealthView.OnChanged -= UpdateSlider;
        }

        private void UpdateHealthText(IHealthParamsProvider healthParams)
        {
            _healthText.text = $"{healthParams.MaxHealth} / {healthParams.CurrentHealth}";
        }

        private void UpdateSlider(IHealthParamsProvider healthParams)
        {
            var healthPercent = healthParams.CurrentHealth / healthParams.MaxHealth;
            
            _healthBar.value = healthPercent;
        }        
    }
}