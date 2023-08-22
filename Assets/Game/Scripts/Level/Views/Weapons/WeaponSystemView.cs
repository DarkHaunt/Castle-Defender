using Game.Level.Binders;
using UnityEngine;
using VContainer;


namespace Game.Level.Views.Weapons
{
    public abstract class WeaponSystemView : MonoBehaviour
    {
        protected WeaponSystemBinder WeaponSystemBinder;


        [Inject]
        private void Construct(WeaponSystemBinder weaponSystemBinder)
        {
            WeaponSystemBinder = weaponSystemBinder;

            WeaponSystemBinder.OnSystemEnabled += Enable;
            WeaponSystemBinder.OnSystemDisabled += Disable;
        }
        
        private void Enable()
        {
            WeaponSystemBinder.CreateOptionSelected.OnChanged += OnCreateOptionSelected;
            WeaponSystemBinder.UpdateOptionSelected.OnChanged += OnUpdateOptionSelected;
            WeaponSystemBinder.DeleteOptionSelected.OnChanged += OnDeleteOptionSelected;

            OnEnableCustom();
        }     
        
        private void Disable()
        {
            WeaponSystemBinder.CreateOptionSelected.OnChanged -= OnCreateOptionSelected;
            WeaponSystemBinder.UpdateOptionSelected.OnChanged -= OnUpdateOptionSelected;
            WeaponSystemBinder.DeleteOptionSelected.OnChanged -= OnDeleteOptionSelected;
            
            OnDisableCustom();
        }

        protected abstract void OnCreateOptionSelected(bool isEnabled);
        protected abstract void OnDeleteOptionSelected(bool isEnabled);
        protected abstract void OnUpdateOptionSelected(bool isEnabled);
        protected abstract void OnDisableCustom();
        protected abstract void OnEnableCustom();
    }
}