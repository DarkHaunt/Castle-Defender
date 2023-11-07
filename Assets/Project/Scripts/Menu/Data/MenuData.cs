using UnityEngine.UI;
using UnityEngine;
using System;


namespace Project.Scripts.Menu.Data
{
    [Serializable]
    public class MenuData
    {
        [field: SerializeField] public Canvas MenuCanvas { get; private set; }
        
        [field: SerializeField] public Button StartButton { get; private set; }
        [field: SerializeField] public Button SettingsButton { get; private set; }
        [field: SerializeField] public Button ShopButton { get; private set; }
        [field: SerializeField] public Button ExitButton { get; private set; }
    }
}