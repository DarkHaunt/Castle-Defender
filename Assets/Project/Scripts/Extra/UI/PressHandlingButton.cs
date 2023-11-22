using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


namespace Project.Scripts.Extra.UI
{
    public sealed class PressHandlingButton : MonoBehaviour
    {
        public event Action OnBeenPressed;
        public event Action OnBeenUnpressed;

        [Header("--- Source ---")]
        [SerializeField] private Image _image;
        [SerializeField] private Button _button;
        
        [Header("--- Visuals ---")]
        [SerializeField] private Sprite _unpressedGraphcics;
        [SerializeField] private Sprite _pressedGraphcics;
        
        private bool _hasBeenPressed;


        public void AddListener(UnityAction listener)
            => _button.onClick.AddListener(listener);

        public void RemoveListener(UnityAction listener)
            => _button.onClick.RemoveListener(listener);

        private void OnEnable()
            => AddListener(ProcessPressState);

        private void OnDisable()
            => RemoveListener(ProcessPressState);

        private void ProcessPressState()
        {
            _hasBeenPressed = !_hasBeenPressed;

            _image.sprite = _hasBeenPressed ? _pressedGraphcics : _unpressedGraphcics;
            
            if (_hasBeenPressed)
                OnBeenPressed?.Invoke();
            else
                OnBeenUnpressed?.Invoke();
        }
    }
}