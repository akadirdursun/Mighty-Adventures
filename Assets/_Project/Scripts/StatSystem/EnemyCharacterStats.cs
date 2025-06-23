using System;
using UnityEngine;

namespace MightyAdventures.StatSystem
{
    [Serializable]
    public class EnemyCharacterStats
    {
        #region Constructors

        public EnemyCharacterStats(
            VitalityStat health,
            PercentileStat damageResistance,
            IntervalStat damage,
            SimpleStat attackSpeed,
            PercentileStat trapSpawnChance,
            SimpleStat maxTrapSpawnCount)
        {
            this.health = health;
            this.damageResistance = damageResistance;
            this.damage = damage;
            this.attackSpeed = attackSpeed;
            this.trapSpawnChance = trapSpawnChance;
            this.maxTrapSpawnCount = maxTrapSpawnCount;
        }

        #endregion

        [SerializeField] private VitalityStat health;
        [SerializeField] private IntervalStat damage;
        [SerializeField] private PercentileStat damageResistance;
        [SerializeField] private SimpleStat attackSpeed;
        [SerializeField] private PercentileStat trapSpawnChance;
        [SerializeField] private SimpleStat maxTrapSpawnCount;

        public VitalityStat Health => health;
        public PercentileStat DamageResistance => damageResistance;
        public IntervalStat Damage => damage;
        public SimpleStat AttackSpeed => attackSpeed;
        public PercentileStat TrapSpawnChance => trapSpawnChance;
        public SimpleStat MaxTrapSpawnCount => maxTrapSpawnCount;


        public EnemyCharacterStats Clone()
        {
            return new EnemyCharacterStats(
                health.Clone(),
                damageResistance.Clone(),
                damage.Clone(),
                attackSpeed.Clone(),
                trapSpawnChance.Clone(),
                maxTrapSpawnCount.Clone());
        }
    }
}