using Game.Configs.Level;
using UnityEngine.UI;
using UnityEngine;
using System;
using TMPro;


namespace Project.Scripts.Menu.UI
{
    [RequireComponent(typeof(Button))]
    public class LevelButton : MonoBehaviour
    {
        public event Action<LevelConfig> OnClicked;
        
        [SerializeField] private LevelConfig _config;
        [SerializeField] private TextMeshProUGUI _numberField;

        private Button _button;

        private void OnValidate()
        {
            if(!_numberField || !_config)
                return;

            _numberField.text = _config.Number.ToString();
        }

        private void Awake()
            => _button = GetComponent<Button>();

        private void OnEnable()
            => _button.onClick.AddListener(NotifyClicked);

        private void OnDisable()
            => _button.onClick.RemoveListener(NotifyClicked);

        private void NotifyClicked()
            => OnClicked?.Invoke(_config);
    }
}