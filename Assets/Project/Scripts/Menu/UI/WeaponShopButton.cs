using Project.Scripts.Configs.Consume;
using Project.Scripts.Consume;
using UnityEngine.UI;
using UnityEngine;
using System;
using TMPro;

namespace Project.Scripts.Menu.UI
{
    [RequireComponent(typeof(Button))]
    public class WeaponShopButton : MonoBehaviour
    {
        public event Action<WeaponConfig> OnSucessConsumed;

        [SerializeField] private WeaponConfig _config;

        [Header("--- UI ---")]
        [SerializeField] private TextMeshProUGUI _coinsText;

        [SerializeField] private GameObject _coinsView;
        [SerializeField] private Image _icon;

        private CoinsHandleService _coinsHandleService;
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _icon.sprite = _config.Icon;
            
            if (_config.IsFree)
                _coinsView.SetActive(false);
            else
                _coinsText.text = _config.Price.ToString();
        }

        private void OnValidate()
        {
            if (_icon && _config)
                _icon.sprite = _config.Icon;
        }

        public void Construct(CoinsHandleService coinsHandleService)
            => _coinsHandleService = coinsHandleService;

        private void TryToConsume()
        {
            if (_config.IsFree)
            {
                OnSucessConsumed?.Invoke(_config);
                return;
            }

            _coinsHandleService.TryToConsume(_config.Price, onSuccess: () => OnSucessConsumed?.Invoke(_config));
        }

        private void OnEnable()
            => _button.onClick.AddListener(TryToConsume);

        private void OnDisable()
            => _button.onClick.RemoveListener(TryToConsume);
    }
}