using Game.Extensions;
using System;
using UnityEngine;


namespace Project.Scripts.Level.Common.Damage
{
    public class HealthParamsHandler : IHealthParamsProvider
    {
        public float MaxHealth { get; }
        public float CurrentHealth { get; private set; }


        public HealthParamsHandler(float initHealth)
        {
            if(initHealth < 0)
                throw new ArgumentException("Health params can't be lower than 0");
            
            CurrentHealth = initHealth;
            MaxHealth = initHealth;
        }


        public void DecreaseHealthBy(float value)
        {
            var clampedHealth = CurrentHealth - value;
            
            CurrentHealth = MathfExtensions.PositiveClamp(clampedHealth);
        }

        public bool IsCurrentHealthZero()
            => Mathf.Approximately(CurrentHealth, 0);
    }
}