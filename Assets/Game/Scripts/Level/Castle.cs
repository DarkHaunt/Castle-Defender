using System.Collections.Generic;
using Interfaces;
using UnityEngine;


namespace Game.Level
{
    public class Castle : ICastle
    {
        private readonly List<Transform> _weaponPoints;

        
        public Castle(IList<Transform> _weaponPoints)
        {
            Debug.Log($"<color=white>Lox i chmo</color>");            
        }

        public Castle()
        {
            Debug.Log($"<color=white>Pizda</color>");
        }

        public void Call()
        {
            Debug.Log($"<color=white>Call</color>");
        }
    }
}