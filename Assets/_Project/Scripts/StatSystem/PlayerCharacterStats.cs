using System;
using UnityEngine;

namespace MightyAdventures.StatSystem
{
    [Serializable]
    public class PlayerCharacterStats
    {
        #region Constructors

        public PlayerCharacterStats(
            VitalityStat health, 
            IntervalStat damage,
            PercentileStat damageResistance, 
            SimpleStat attackSpeed,
            SimpleStat maxSkillTokenCount)
        {
            this.health = health;
            this.damage = damage;
            this.damageResistance = damageResistance;
            this.attackSpeed = attackSpeed;
            this.maxSkillTokenCount = maxSkillTokenCount;
        }

        #endregion

        [SerializeField] private VitalityStat health;
        [SerializeField] private IntervalStat damage;
        [SerializeField] private PercentileStat damageResistance;
        [SerializeField] private SimpleStat attackSpeed;
        [SerializeField] private SimpleStat maxSkillTokenCount;

        public VitalityStat Health => health;
        public IntervalStat Damage => damage;
        public PercentileStat DamageResistance => damageResistance;
        public SimpleStat AttackSpeed => attackSpeed;
        public SimpleStat MaxSkillTokenCount => maxSkillTokenCount;


        public PlayerCharacterStats Clone()
        {
            return new PlayerCharacterStats(
                health.Clone(), 
                damage.Clone(), 
                damageResistance.Clone(), 
                attackSpeed.Clone(),
                maxSkillTokenCount.Clone());
        }
    }
}