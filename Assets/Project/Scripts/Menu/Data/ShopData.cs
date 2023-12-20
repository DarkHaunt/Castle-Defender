using System;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Menu.Data
{
    [Serializable]
    public class ShopData
    {
        [field: SerializeField] public Canvas ShopCanvas { get; private set; }
        [field: SerializeField] public Button ExitButton { get; private set; }
    }
}