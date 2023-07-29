using System.Collections.Generic;
using Game.Level.Weapon;
using System;


namespace Game.Level.Castle
{
    public class CastleModel : ICastle
    {
        public event Action OnDamaged;
        
        
        public CastleModel(IList<WeaponPlacePoint> lox)
        {
        }

        public void GetDamage(float damage)
        {
        }
    }
}