using UnityEngine.UI; 
using UnityEngine;
using System;


namespace Game.Level.Weapons.HandlePoints
{
    public class WeaponHandlePoint : MonoBehaviour
    {
        public event Action<WeaponHandlePoint> OnCreateButtonPressed;
        public event Action<WeaponHandlePoint> OnUpdateButtonPressed;
        public event Action<WeaponHandlePoint> OnDeleteButtonPressed;
        
        
        [Header("--- Create View ---")]
        [SerializeField] private Button _createWeaponButton;
        [SerializeField] private Canvas _createWeaponView;
        
        [Header("--- Delete View ---")]
        [SerializeField] private Button _deleteButton;
        [SerializeField] private Canvas _deleteView;  
        
        [Header("--- Update View ---")]
        [SerializeField] private Button _updateButton;
        [SerializeField] private Canvas _updateView;

        private Weapon _handledWeapon;

        public Vector2 Position => transform.position;
        
        
        public void RegisterWeapon(Weapon weapon)
            => _handledWeapon = weapon;

        public void DeleteWeapon()
            => Destroy(_handledWeapon.gameObject);
        
        public void EnableCreateView()
        {
            _createWeaponButton.onClick.AddListener(OnCreateButtonClick);
            _createWeaponView.gameObject.SetActive(true);
        }

        public void DisableCreateView()
        {
            _createWeaponButton.onClick.RemoveListener(OnCreateButtonClick);
            _createWeaponView.gameObject.SetActive(false);
        }
        
        public void EnableDeleteView()
        {
            _deleteButton.onClick.AddListener(OnDeleteButtonClick);
            _deleteView.gameObject.SetActive(true);
        }

        public void DisableDeleteView()
        {
            _deleteButton.onClick.RemoveListener(OnDeleteButtonClick);
            _deleteView.gameObject.SetActive(false);
        }      
        
        public void EnableUpdateView()
        {
            _updateButton.onClick.AddListener(OnUpdateButtonClick);
            _updateView.gameObject.SetActive(true);
        }

        public void DisableUpdateView()
        {
            _updateButton.onClick.RemoveListener(OnUpdateButtonClick);
            _updateView.gameObject.SetActive(false);
        }
        
        private void OnCreateButtonClick()
            => OnCreateButtonPressed?.Invoke(this); 
        
        private void OnDeleteButtonClick()
            => OnDeleteButtonPressed?.Invoke(this);
        
        private void OnUpdateButtonClick()
            => OnUpdateButtonPressed?.Invoke(this);    
    }
}