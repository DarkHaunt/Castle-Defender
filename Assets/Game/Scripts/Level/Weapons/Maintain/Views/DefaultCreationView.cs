using Game.Extra.UI;
using UnityEngine;


namespace Game.Level.Weapons.Maintain.Views
{
    public class DefaultCreationView : WeaponCreationView
    {
        [Header("--- Buttons ---")]
        [SerializeField] private PressHandlingButton _createButton;
        [SerializeField] private PressHandlingButton _updateButton;
        [SerializeField] private PressHandlingButton _deleteButton;


        protected override void OnCreateEnabled(bool isEnabled)
        {
            _updateButton.gameObject.SetActive(!isEnabled);
            _deleteButton.gameObject.SetActive(!isEnabled);
        }

        protected override void OnDeleteEnabled(bool isEnabled)
        {
            _createButton.gameObject.SetActive(!isEnabled);
            _updateButton.gameObject.SetActive(!isEnabled);
        }

        protected override void OnUpdateEnabled(bool isEnabled)
        {
            _createButton.gameObject.SetActive(!isEnabled);
            _deleteButton.gameObject.SetActive(!isEnabled);
        }

        protected override void Enable()
        {
            _createButton.OnBeenPressed +=  WeaponCreateBinder.EnableCreation;
            _createButton.OnBeenUnpressed += WeaponCreateBinder.DisableCreation;
            
            _deleteButton.OnBeenPressed += WeaponCreateBinder.EnableDeletion;
            _deleteButton.OnBeenUnpressed += WeaponCreateBinder.DisableDeletion;
        }

        protected override void Disable()
        {
            _createButton.OnBeenPressed -= WeaponCreateBinder.EnableCreation;
            _deleteButton.OnBeenPressed -= WeaponCreateBinder.EnableDeletion;
            
            _createButton.OnBeenUnpressed -= WeaponCreateBinder.DisableCreation;
        }
    }
}