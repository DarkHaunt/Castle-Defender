using System.Collections.Generic;
using Project.Scripts.Menu.UI;
using UnityEngine;
using System;


namespace Project.Scripts.Menu.Data
{
    [Serializable]
    public class LevelSelectData
    {
        [field: SerializeField] public List<LevelButton> LevelButtons { get; private set; }
        [field: SerializeField] public Canvas LevelSelectCanvas { get; private set; }
    }
}