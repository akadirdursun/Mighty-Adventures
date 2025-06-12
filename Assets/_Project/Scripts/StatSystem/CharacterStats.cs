using System;
using UnityEngine;

namespace MightyAdventures.StatSystem
{
    [Serializable]
    public class CharacterStats
    {
        #region Constructors

        public CharacterStats(SimpleStat health, SimpleStat healthRegen, IntervalStat damage, SimpleStat damageResistance)
        {
            this.health = health;
            this.healthRegen = healthRegen;
            this.damage = damage;
            this.damageResistance = damageResistance;
        }

        #endregion

        [SerializeField] private SimpleStat health;
        [SerializeField] private SimpleStat healthRegen;
        [SerializeField] private IntervalStat damage;
        [SerializeField] private SimpleStat damageResistance;

        public SimpleStat Health => health;
        public SimpleStat HealthRegen => healthRegen;
        public IntervalStat Damage => damage;
        public SimpleStat DamageResistance => damageResistance;


        public CharacterStats Clone()
        {
            return new CharacterStats(health.Clone(), healthRegen.Clone(), damage.Clone(), damageResistance.Clone());
        }
    }
}