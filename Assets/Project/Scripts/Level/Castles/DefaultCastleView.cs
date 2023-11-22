using Project.Scripts.Level.Common.Damage;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


namespace Project.Scripts.Level.Castles
{
    public class DefaultCastleView : CastleView
    {
        [Header("--- GUI View ---")]
        [SerializeField] private Image _healthBar;
        [SerializeField] private TextMeshProUGUI _healthText;


        protected override void OnEnableCustom()
        {
            _healthBar.gameObject.SetActive(true);
            _healthText.gameObject.SetActive(true);
        }

        protected override void OnDisableCustom()
        {
            _healthBar.gameObject.SetActive(false);
            _healthText.gameObject.SetActive(false);
        }

        protected override void UpdateHealthText(IHealthParamsProvider healthParams)
        {
            _healthText.text = $"{healthParams.MaxHealth} / {healthParams.CurrentHealth}";
        }

        protected override void UpdateHealth(IHealthParamsProvider healthParams)
        {
            var healthPercent = healthParams.CurrentHealth / healthParams.MaxHealth;
            
            _healthBar.fillAmount = healthPercent;
        }        
    }
}