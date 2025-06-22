using System;
using UnityEngine;

namespace MightyAdventures.StatSystem
{
    [Serializable]
    public class CharacterStats
    {
        #region Constructors

        public CharacterStats(
            VitalityStat health, 
            SimpleStat healthRegen, 
            PercentileStat damageResistance, 
            IntervalStat damage,
            SimpleStat attackSpeed,
            SimpleStat attackTokenCount)
        {
            this.health = health;
            this.healthRegen = healthRegen;
            this.damageResistance = damageResistance;
            this.damage = damage;
            this.attackSpeed = attackSpeed;
            this.attackTokenCount = attackTokenCount;
        }

        #endregion

        [SerializeField] private VitalityStat health;
        [SerializeField] private SimpleStat healthRegen;
        [SerializeField] private PercentileStat damageResistance;
        [SerializeField] private IntervalStat damage;
        [SerializeField] private SimpleStat attackSpeed;
        [SerializeField] private SimpleStat attackTokenCount;

        public VitalityStat Health => health;
        public SimpleStat HealthRegen => healthRegen;
        public PercentileStat DamageResistance => damageResistance;
        public IntervalStat Damage => damage;
        public SimpleStat AttackSpeed => attackSpeed;
        public SimpleStat AttackTokenCount => attackTokenCount;


        public CharacterStats Clone()
        {
            return new CharacterStats(
                health.Clone(), 
                healthRegen.Clone(), 
                damageResistance.Clone(), 
                damage.Clone(), 
                attackSpeed.Clone(),
                attackTokenCount.Clone());
        }
    }
}