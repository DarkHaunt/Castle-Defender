﻿using Game.Extra.UI;
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
            
            _createButton.OnBeenPressed +=  _weaponSystemBinder.CreateEnable;
            _createButton.OnBeenUnpressed += _weaponSystemBinder.CreateDisable;
            
            _deleteButton.OnBeenPressed += _weaponSystemBinder.DeleteEnable;
            _deleteButton.OnBeenUnpressed += _weaponSystemBinder.DeleteDisable;            
            
            _updateButton.OnBeenPressed += _weaponSystemBinder.UpdateEnable;
            _updateButton.OnBeenUnpressed += _weaponSystemBinder.UpdateDisable;
        }

        protected override void OnDisableCustom()
        {
            DisableAllButtons();
            
            _createButton.OnBeenPressed -= _weaponSystemBinder.CreateEnable;
            _createButton.OnBeenUnpressed -= _weaponSystemBinder.CreateDisable;
            
            _deleteButton.OnBeenPressed -= _weaponSystemBinder.DeleteEnable;
            _deleteButton.OnBeenUnpressed -= _weaponSystemBinder.DeleteDisable;            
            
            _updateButton.OnBeenPressed += _weaponSystemBinder.UpdateEnable;
            _updateButton.OnBeenUnpressed += _weaponSystemBinder.UpdateDisable;
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