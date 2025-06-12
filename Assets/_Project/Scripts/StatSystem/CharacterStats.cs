using System;
using UnityEngine;

namespace MightyAdventures.StatSystem
{
    [Serializable]
    public class CharacterStats
    {
        #region Constructors

        public CharacterStats(SimpleStat health, SimpleStat healthRegen, SimpleStat damageResistance, IntervalStat damage)
        {
            this.health = health;
            this.healthRegen = healthRegen;
            this.damageResistance = damageResistance;
            this.damage = damage;
        }

        #endregion

        [SerializeField] private SimpleStat health;
        [SerializeField] private SimpleStat healthRegen;
        [SerializeField] private SimpleStat damageResistance;
        [SerializeField] private IntervalStat damage;

        public SimpleStat Health => health;
        public SimpleStat HealthRegen => healthRegen;
        public SimpleStat DamageResistance => damageResistance;
        public IntervalStat Damage => damage;


        public CharacterStats Clone()
        {
            return new CharacterStats(health.Clone(), healthRegen.Clone(), damageResistance.Clone(), damage.Clone());
        }
    }
}