using Game.Level.Weapons.Create.Binder;
using UnityEngine;
using VContainer;


namespace Game.Level.Weapons.Create.View
{
    public abstract class WeaponCreationView : MonoBehaviour
    {
        protected WeaponCreateBinder WeaponCreateBinder;


        [Inject]
        private void Construct(WeaponCreateBinder weaponCreateBinder)
        {
            WeaponCreateBinder = weaponCreateBinder;
        }
        
        private void OnEnable()
        {
            WeaponCreateBinder.CreateEnabled.OnChanged += OnCreateEnabled;
            WeaponCreateBinder.UpdateEnabled.OnChanged += OnUpdateEnabled;
            WeaponCreateBinder.DeleteEnabled.OnChanged += OnDeleteEnabled;

            Enable();
        }     
        
        private void OnDisable()
        {
            WeaponCreateBinder.CreateEnabled.OnChanged -= OnCreateEnabled;
            WeaponCreateBinder.UpdateEnabled.OnChanged -= OnUpdateEnabled;
            WeaponCreateBinder.DeleteEnabled.OnChanged -= OnDeleteEnabled;
            
            Disable();
        }

        protected abstract void OnCreateEnabled(bool isEnabled);
        protected abstract void OnDeleteEnabled(bool isEnabled);
        protected abstract void OnUpdateEnabled(bool isEnabled);
        protected abstract void Enable();
        protected abstract void Disable();
    }
}