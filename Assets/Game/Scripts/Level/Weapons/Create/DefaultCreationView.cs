using Game.Extra.UI;
using UnityEngine;


namespace Game.Level.Weapons.Create
{
    public class DefaultCreationView : WeaponCreationView
    {
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
            _createButton.OnBeenPressed += _weaponCreationBinder.EnableCreation;
            _createButton.OnBeenUnpressed += _weaponCreationBinder.DisableCreation;
        }

        protected override void Disable()
        {
            _createButton.OnBeenPressed -= _weaponCreationBinder.EnableCreation;
            _createButton.OnBeenUnpressed -= _weaponCreationBinder.DisableCreation;
        }
    }
}