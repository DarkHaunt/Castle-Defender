using Project.Scripts.Level.Common.Crystals;
using Project.Scripts.Configs.Game.Weapons;
using Project.Scripts.Consume;
using UnityEngine.UI;
using UnityEngine;
using System;

namespace Project.Scripts.Level.Weapons.View
{
    public class WeaponPickButton : MonoBehaviour
    {
        public event Action<WeaponCreateConfig> OnChosenPrefab;

        
        [field: Header("--- Base ---")]
        [field: SerializeField] public WeaponCreateConfig Config { get; private set; }
        [SerializeField] private Image _icon;
        
        [Header("--- Price ---")]
        [SerializeField] private PriceView _priceView;
        
        [Header("--- Lock ---")]
        [SerializeField] private GameObject _lockView;
        
        private bool _isLocked = true;
        private Button _button;


        private void OnValidate()
            => SetConfigData();

        private void Awake()
        {
            _button = GetComponent<Button>();

            SetConfigData();
        }

        private void OnEnable()
            => _button.onClick.AddListener(TryToPick);

        private void OnDisable()
            => _button.onClick.RemoveListener(TryToPick);
        
        private void SetConfigData()
        {
            if (!Config)
                return;

            if (_icon)
                _icon.sprite = Config.Icon;

            if (_priceView)
                _priceView.UpdatePriceText(Config.Price);
        }

        private void TryToPick()
        {
            if(_isLocked)
                return;

            OnChosenPrefab?.Invoke(Config);
        }

        public void Unlock()
        {
            _lockView.SetActive(false);
            _priceView.Show();

            _isLocked = false; 
        }
    }
}