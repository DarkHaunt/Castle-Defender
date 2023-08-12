using UnityEngine;
using VContainer;


namespace Game.Level.Weapons.Create
{
    public abstract class WeaponCreationView : MonoBehaviour
    {
        protected WeaponCreationBinder _weaponCreationBinder;


        [Inject]
        private void Construct(WeaponCreationBinder weaponCreationBinder)
        {
            _weaponCreationBinder = weaponCreationBinder;
        }
        
        private void OnEnable()
        {
            _weaponCreationBinder.Enable();
            _weaponCreationBinder.CreationEnabled.OnChanged += OnCreationEnabled;

            Enable();
        }     
        
        private void OnDisable()
        {
            _weaponCreationBinder.Disable();
            _weaponCreationBinder.CreationEnabled.OnChanged -= OnCreationEnabled;
            
            Disable();
        }

        protected abstract void OnCreationEnabled(bool isEnabled);
        protected abstract void Enable();
        protected abstract void Disable();
    }
}