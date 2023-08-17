using Game.Level.Weapons.StateMachine;
using UnityEngine.UI;
using UnityEngine;
using System;


namespace Game.Level.Weapons
{
    public class Weapon : MonoBehaviour
    {
        public event Action<Weapon> OnDeleteButtonPressed; 
        public event Action<Weapon> OnUpdateButtonPressed; 

        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Collider2D _attackRange;

        [Header("--- Delete View ---")]
        [SerializeField] private Button _deleteButton;
        [SerializeField] private Canvas _deleteView;  
        
        [Header("--- Update View ---")]
        [SerializeField] private Button _updateButton;
        [SerializeField] private Canvas _updateView;

        private WeaponStateMachine _weaponStateMachine;
        
        
        public void EnableDeleteUI()
        {
            _deleteButton.onClick.AddListener(OnDeleteButtonClick);
            _deleteView.gameObject.SetActive(true);
        }

        public void DisableDeleteUI()
        {
            _deleteButton.onClick.RemoveListener(OnDeleteButtonClick);
            _deleteView.gameObject.SetActive(false);
        }      
        
        public void EnableUpdateUI()
        {
            _updateButton.onClick.AddListener(OnUpdateButtonClick);
            _updateView.gameObject.SetActive(true);
        }

        public void DisableUpdateUI()
        {
            _updateButton.onClick.RemoveListener(OnUpdateButtonClick);
            _updateView.gameObject.SetActive(false);
        }

        private void OnDeleteButtonClick()
            => OnDeleteButtonPressed?.Invoke(this); 
        
        private void OnUpdateButtonClick()
            => OnUpdateButtonPressed?.Invoke(this);
    }
}