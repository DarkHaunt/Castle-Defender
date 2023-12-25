using Project.Scripts.Configs.Consume;
using Project.Scripts.Consume;
using Project.Scripts.Global;
using UnityEngine.UI;
using UnityEngine;
using System;
using TMPro;

namespace Project.Scripts.Menu.UI
{
    [RequireComponent(typeof(Button))]
    public class WeaponShopButton : MonoBehaviour
    {
        public event Action<WeaponConfig> OnSuccessConsumed;
        [field: SerializeField] public WeaponConfig Config { get; private set; }

        [Header("--- UI ---")]
        [SerializeField] private TextMeshProUGUI _coinsText;

        [SerializeField] private GameObject _coinsView;
        [SerializeField] private Image _icon;

        private CoinsHandleService _coinsHandleService;
        private bool _isPurchased;
        private Button _button;
        
        public WeaponType Type => Config.Type;
        
        

        private void Awake()
        {
            _button = GetComponent<Button>();
            SetConfigData();
        }

        private void OnValidate()
            => SetConfigData();

        private void OnEnable()
            => _button.onClick.AddListener(TryToConsume);

        private void OnDisable()
            => _button.onClick.RemoveListener(TryToConsume);

        private void SetConfigData()
        {
            if (!Config)
                return;

            if (_icon)
                _icon.sprite = Config.Icon;

            if (_coinsText)
                _coinsText.text = Config.Price.ToString();
        }

        public void Construct(CoinsHandleService coinsHandleService)
            => _coinsHandleService = coinsHandleService;

        private void TryToConsume()
        {
            if(_isPurchased)
                return;
            
            _coinsHandleService.TryToConsume(Config.Price, onSuccess: OnSuccessConsume);
        }

        private void OnSuccessConsume()
        {
            OnSuccessConsumed?.Invoke(Config);
            Unlock();
        }

        public void Unlock()
        {
            _coinsView.SetActive(false);
            _isPurchased = true; 
        }
    }
}