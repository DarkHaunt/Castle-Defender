using Project.Scripts.Level.Weapons.Handling;
using System.Collections.Generic;
using UnityEngine;
using VContainer;


namespace Project.Scripts.Level.Weapons.View
{
    public abstract class WeaponSystemView : MonoBehaviour
    {
        [field: SerializeField] public List<WeaponPickButton> PickButtons { get; private set; }
        
        protected WeaponSystemBinder _weaponSystemBinder;
        

        [Inject]
        private void Construct(WeaponSystemBinder weaponSystemBinder)
        {
            _weaponSystemBinder = weaponSystemBinder;

            _weaponSystemBinder.OnSystemEnabled += Enable;
            _weaponSystemBinder.OnSystemDisabled += Disable;
        }
        
        private void Enable()
        {
            _weaponSystemBinder.CreateOptionSelected.OnChanged += OnCreateOptionSelected;
            _weaponSystemBinder.DeleteOptionSelected.OnChanged += OnDeleteOptionSelected;

            OnEnableCustom();
        }     
        
        private void Disable()
        {
            _weaponSystemBinder.CreateOptionSelected.OnChanged -= OnCreateOptionSelected;
            _weaponSystemBinder.DeleteOptionSelected.OnChanged -= OnDeleteOptionSelected;
            
            OnDisableCustom();
        }

        protected abstract void OnCreateOptionSelected(bool isEnabled);
        protected abstract void OnDeleteOptionSelected(bool isEnabled);
        protected abstract void OnDisableCustom();
        protected abstract void OnEnableCustom();
    }
}