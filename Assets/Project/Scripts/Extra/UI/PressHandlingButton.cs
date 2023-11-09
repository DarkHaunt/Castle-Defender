using System;
using UnityEngine.Events;
using UnityEngine.UI;


namespace Project.Scripts.Extra.UI
{
    public sealed class PressHandlingButton : Button
    {
        public event Action OnBeenPressed;
        public event Action OnBeenUnpressed;

        private bool _hasBeenPressed;


        public void AddListener(UnityAction listener)
            => onClick.AddListener(listener);

        public void RemoveListener(UnityAction listener)
            => onClick.RemoveListener(listener);    
        
        protected override void OnEnable()
        {
            base.OnEnable();

            AddListener(ProcessPressState);
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            RemoveListener(ProcessPressState);
        }

        private void ProcessPressState()
        {
            _hasBeenPressed = !_hasBeenPressed;

            if (_hasBeenPressed)
                OnBeenPressed?.Invoke();
            else
                OnBeenUnpressed?.Invoke();
        }
    }
}