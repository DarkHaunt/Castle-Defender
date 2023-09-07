using Game.Level.Common.Damage;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


namespace Game.Level.Views.Castles
{
    public class DefaultCastleView : CastleView
    {
        [Header("--- GUI View ---")]
        [SerializeField] private Slider _healthBar;
        [SerializeField] private TextMeshProUGUI _healthText;


        protected override void Enable()
        {
            _healthBar.gameObject.SetActive(true);
            _healthText.gameObject.SetActive(true);
            
            _castleBinder.HealthView.OnChanged += UpdateHealthText;
            _castleBinder.HealthView.OnChanged += UpdateSlider;
        }

        protected override void Disable()
        {
            _healthBar.gameObject.SetActive(false);
            _healthText.gameObject.SetActive(false);
            
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