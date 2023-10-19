using Game.Level.Weapons.HandlePoints.MVP;
using Game.Level.Weapons.HandlePoints;
using System.Collections.Generic;
using Game.Level.Common.Damage;
using UnityEngine;


namespace Game.Level.Castles
{
    public class Castle : MonoBehaviour
    {
        [field: SerializeField] public CollideAttackTarget PhysicBody { get; private set; }
        [field: SerializeField] public List<WeaponPointView> WeaponHandlePoints { get; private set; }

        public IList<WeaponPointModel> CreateAllWeaponPoints()
        {
            var weapons = new List<WeaponPointModel>(WeaponHandlePoints.Count);

            foreach (var view in WeaponHandlePoints)
            {
                var model = new WeaponPointModel(view.transform.position);
                var presenter = new WeaponPointPresenter(model, view);
                
                weapons.Add(model);
            }

            return weapons;
        }
    }
}