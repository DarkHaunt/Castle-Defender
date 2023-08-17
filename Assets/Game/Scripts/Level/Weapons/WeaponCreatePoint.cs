using UnityEngine.UI;
using UnityEngine;
using System;


namespace Game.Level.Weapons
{
    public class WeaponCreatePoint : MonoBehaviour
    {
        public event Action<WeaponCreatePoint> OnCreateButtonPressed;
        
        [Header("--- Create View ---")]
        [SerializeField] private Button _createWeaponButton;
        [SerializeField] private Canvas _createWeaponView;


        public void EnableCreateUI()
        {
            _createWeaponButton.onClick.AddListener(OnCreateButtonClick);
            _createWeaponView.gameObject.SetActive(true);
        }

        public void DisableCreateUI()
        {
            _createWeaponButton.onClick.RemoveListener(OnCreateButtonClick);
            _createWeaponView.gameObject.SetActive(false);
        }

        private void OnCreateButtonClick()
            => OnCreateButtonPressed?.Invoke(this);
    }
}