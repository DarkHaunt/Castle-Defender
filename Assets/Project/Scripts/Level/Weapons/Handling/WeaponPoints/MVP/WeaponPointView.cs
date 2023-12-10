using System;
using UnityEngine;
using UnityEngine.UI;


namespace Project.Scripts.Level.Weapons.Handling.WeaponPoints.MVP
{
    public class WeaponPointView : MonoBehaviour
    {
        public event Action OnCreateButtonPressed;
        public event Action OnUpdateButtonPressed;
        public event Action OnDeleteButtonPressed;


        [Header("--- Create View ---")]
        [SerializeField] private Button _createWeaponButton;
        [SerializeField] private Canvas _createWeaponView;

        [Header("--- Delete View ---")]
        [SerializeField] private Button _deleteButton;
        [SerializeField] private Canvas _deleteView;

        [Header("--- Update View ---")]
        [SerializeField] private Button _updateButton;
        [SerializeField] private Canvas _updateView;


        private void OnEnable()
        {
            _createWeaponButton.onClick.AddListener(OnCreateButtonClick);
            _deleteButton.onClick.AddListener(OnDeleteButtonClick);
            _updateButton.onClick.AddListener(OnUpdateButtonClick);
        }

        private void OnDisable()
        {
            _createWeaponButton.onClick.RemoveListener(OnCreateButtonClick);
            _deleteButton.onClick.RemoveListener(OnDeleteButtonClick);
            _updateButton.onClick.RemoveListener(OnUpdateButtonClick);
        }

        
        public void EnableCreateView(bool enable)
            => _createWeaponView.gameObject.SetActive(enable);

        public void EnableUpdateView(bool enable)
            => _updateView.gameObject.SetActive(enable);

        public void EnableDeleteView(bool enable)
            => _deleteView.gameObject.SetActive(enable);


        private void OnCreateButtonClick()
            => OnCreateButtonPressed?.Invoke();

        private void OnUpdateButtonClick()
            => OnUpdateButtonPressed?.Invoke();

        private void OnDeleteButtonClick()
            => OnDeleteButtonPressed?.Invoke();
    }
}