using System;
using UnityEngine;

namespace MightyAdventures.StatSystem
{
    [Serializable]
    public class Stats
    {
        #region Constructors

        public Stats(float maxHealth, float healthRegen, int minDamage, int maxDamage)
        {
            this.maxHealth = maxHealth;
            this.healthRegen = healthRegen;
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
            CurrentHealth = maxHealth;
        }

        #endregion

        [SerializeField] private float maxHealth;
        [SerializeField] private float healthRegen;
        [SerializeField] private int minDamage;
        [SerializeField] private int maxDamage;
        [SerializeField, Range(0f, 100f)] private float damageResistance;
        
        public float CurrentHealth { get; }

        public float MaxHealth => maxHealth;
        public float HealthRegen => healthRegen;
        public int MinDamage => minDamage;
        public int MaxDamage => maxDamage;
        public float DamageResistance => damageResistance;

        public Stats Clone()
        {
            return new Stats(maxHealth, healthRegen, minDamage, maxDamage);
        }
    }
}