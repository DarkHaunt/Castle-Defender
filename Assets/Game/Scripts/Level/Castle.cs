using System.Collections.Generic;
using Game.Extensions;
using Interfaces;
using UnityEngine;


namespace Game.Level
{
    public class Castle : ICastle
    {
        public Castle(IList<Transform> lox)
        {
            Debug.Log($"<color=white>Lox i chmo - {lox.Count}</color>");
        }

        public void TestPrint()
        {
            Debug.Log($"<color=white>HER</color>");
        }
    }
}