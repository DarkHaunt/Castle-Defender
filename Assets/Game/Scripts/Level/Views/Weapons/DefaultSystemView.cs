using Game.Extra.UI;
using UnityEngine;


namespace Game.Level.Views.Weapons
{
    public class DefaultSystemView : WeaponSystemView
    {
        [Header("--- Buttons ---")]
        [SerializeField] private PressHandlingButton _createButton;
        [SerializeField] private PressHandlingButton _updateButton;
        [SerializeField] private PressHandlingButton _deleteButton;


        protected override void OnEnableCustom()
        {
            EnableAllButtons();
            
            _createButton.OnBeenPressed +=  WeaponSystemBinder.CreateEnable;
            _createButton.OnBeenUnpressed += WeaponSystemBinder.CreateDisable;
            
            _deleteButton.OnBeenPressed += WeaponSystemBinder.DeleteEnable;
            _deleteButton.OnBeenUnpressed += WeaponSystemBinder.DeleteDisable;            
            
            _updateButton.OnBeenPressed += WeaponSystemBinder.UpdateEnable;
            _updateButton.OnBeenUnpressed += WeaponSystemBinder.UpdateDisable;
        }

        protected override void OnDisableCustom()
        {
            DisableAllButtons();
            
            _createButton.OnBeenPressed -= WeaponSystemBinder.CreateEnable;
            _createButton.OnBeenUnpressed -= WeaponSystemBinder.CreateDisable;
            
            _deleteButton.OnBeenPressed -= WeaponSystemBinder.DeleteEnable;
            _deleteButton.OnBeenUnpressed -= WeaponSystemBinder.DeleteDisable;            
            
            _updateButton.OnBeenPressed += WeaponSystemBinder.UpdateEnable;
            _updateButton.OnBeenUnpressed += WeaponSystemBinder.UpdateDisable;
        }

        protected override void OnCreateOptionSelected(bool isEnabled)
        {
            _updateButton.gameObject.SetActive(!isEnabled);
            _deleteButton.gameObject.SetActive(!isEnabled);
        }

        protected override void OnDeleteOptionSelected(bool isEnabled)
        {
            _createButton.gameObject.SetActive(!isEnabled);
            _updateButton.gameObject.SetActive(!isEnabled);
        }

        protected override void OnUpdateOptionSelected(bool isEnabled)
        {
            _createButton.gameObject.SetActive(!isEnabled);
            _deleteButton.gameObject.SetActive(!isEnabled);
        }

        private void EnableAllButtons()
        {
            _createButton.gameObject.SetActive(true);
            _updateButton.gameObject.SetActive(true);
            _deleteButton.gameObject.SetActive(true);   
        }

        private void DisableAllButtons()
        {
            _createButton.gameObject.SetActive(false);
            _updateButton.gameObject.SetActive(false);
            _deleteButton.gameObject.SetActive(false);
        }
    }
}