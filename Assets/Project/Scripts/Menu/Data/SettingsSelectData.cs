using System;
using UnityEngine.UI;
using UnityEngine;


namespace Project.Scripts.Menu.Data
{
    [Serializable]
    public class SettingsSelectData
    {
        [field: SerializeField] public Canvas SettingsCanvas { get; private set; }
        
        [field: SerializeField] public Button CloseButton { get; private set; }
    }
}