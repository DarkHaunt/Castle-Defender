using Project.Scripts.Common.UI;
using UnityEngine;


namespace Project.Scripts.Level.Weapons.View
{
    public class DefaultSystemView : WeaponSystemView
    {
        [Header("--- Buttons ---")]
        [SerializeField] private PressHandlingButton _createButton;
        [SerializeField] private PressHandlingButton _deleteButton;


        protected override void OnEnableCustom()
        {
            EnableAllButtons();
            
            _createButton.OnBeenPressed +=  _weaponSystemBinder.CreateEnable;
            _createButton.OnBeenUnpressed += _weaponSystemBinder.CreateDisable;
            
            _deleteButton.OnBeenPressed += _weaponSystemBinder.DeleteEnable;
            _deleteButton.OnBeenUnpressed += _weaponSystemBinder.DeleteDisable;            
        }

        protected override void OnDisableCustom()
        {
            DisableAllButtons();
            
            _createButton.OnBeenPressed -= _weaponSystemBinder.CreateEnable;
            _createButton.OnBeenUnpressed -= _weaponSystemBinder.CreateDisable;
            
            _deleteButton.OnBeenPressed -= _weaponSystemBinder.DeleteEnable;
            _deleteButton.OnBeenUnpressed -= _weaponSystemBinder.DeleteDisable;            
        }

        protected override void OnCreateOptionSelected(bool isEnabled)
            => _deleteButton.gameObject.SetActive(!isEnabled);

        protected override void OnDeleteOptionSelected(bool isEnabled)
            => _createButton.gameObject.SetActive(!isEnabled);

        private void EnableAllButtons()
        {
            _createButton.gameObject.SetActive(true);
            _deleteButton.gameObject.SetActive(true);   
        }

        private void DisableAllButtons()
        {
            _createButton.gameObject.SetActive(false);
            _deleteButton.gameObject.SetActive(false);
        }
    }
}