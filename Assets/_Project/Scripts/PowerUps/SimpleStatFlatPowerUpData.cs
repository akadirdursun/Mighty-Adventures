using System;
using MightyAdventures.StatSystem;
using UnityEngine;

namespace MightyAdventures.PowerUps
{
    [CreateAssetMenu(fileName = "NewSimpleStatFlatPowerUpData", menuName = "Mighty Adventures/Power Ups/Simple Stat Flat Power Up")]
    public class SimpleStatFlatPowerUpData : AbstractPowerUpData
    {
        [SerializeField] private SimpleStatTypes statType;
        [SerializeField] private float statIncrease;

        public override void ApplyPowerUp(PlayerCharacterStats stats)
        {
            var simpleStat = GetStat();
            simpleStat.ChangeValue(statIncrease);

            SimpleStat GetStat()
            {
                return statType switch
                {
                    SimpleStatTypes.AttackSpeed => stats.AttackSpeed,
                    SimpleStatTypes.SkillTokenCount => stats.MaxSkillTokenCount,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
        }

        public override string GetDescription()
        {
            var colorHex = GetColorHexCode();
            return $"Increase <color=#{colorHex}>{statType}</color> by {statIncrease}";
        }
    }
}