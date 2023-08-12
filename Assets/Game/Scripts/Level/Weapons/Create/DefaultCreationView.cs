using Game.Extra.UI;
using UnityEngine;
using UnityEngine.Serialization;


namespace Game.Level.Weapons.Create
{
    public class DefaultCreationView : WeaponCreationView
    {
        [FormerlySerializedAs("_prefab")]
        [Header("--- TEST ---")]
        [SerializeField] private Weapon _weaponPrefab;
        
        [SerializeField] private PressHandlingButton _createButton;
        [SerializeField] private PressHandlingButton _updateButton;
        [SerializeField] private PressHandlingButton _deleteButton;


        protected override void OnCreationEnabled(bool isEnabled)
        {
            _updateButton.gameObject.SetActive(!isEnabled);
            _deleteButton.gameObject.SetActive(!isEnabled);
        }

        protected override void Enable()
        {
            _createButton.OnBeenPressed += EnableCreation;
            _createButton.OnBeenUnpressed += _weaponCreationBinder.DisableCreation;
        }

        protected override void Disable()
        {
            _createButton.OnBeenPressed -= EnableCreation;
            _createButton.OnBeenUnpressed -= _weaponCreationBinder.DisableCreation;
        }

        private void EnableCreation()
        {
            _weaponCreationBinder.EnableCreation(_weaponPrefab);
        }
    }
}