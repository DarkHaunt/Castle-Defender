using Project.Scripts.Global;
using UnityEngine.UI;
using UnityEngine;
using System;

namespace Project.Scripts.Level.Weapons.View
{
    public class WeaponPickButton : MonoBehaviour
    {
        public event Action<Weapon> OnChosenPrefab;

        [field: SerializeField] public WeaponType Type { get; private set; }
        [field: SerializeField] public Weapon Prefab { get; private set; }
        
        [SerializeField] private GameObject _lockView;
        
        private bool _isLocked = true;
        private Button _button;
        

        private void Awake()
            => _button = GetComponent<Button>();

        private void OnEnable()
            => _button.onClick.AddListener(TryToPick);

        private void OnDisable()
            => _button.onClick.RemoveListener(TryToPick);

        private void TryToPick()
        {
            if(_isLocked)
                return;
            
            OnChosenPrefab?.Invoke(Prefab);
        }

        public void Unlock()
        {
            _lockView.SetActive(false);
            _isLocked = false; 
        }
    }
}