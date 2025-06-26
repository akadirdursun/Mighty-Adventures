using System;
using MightyAdventures.StatSystem;
using UnityEngine;

namespace MightyAdventures.PowerUps
{
    [CreateAssetMenu(fileName = "NewSimpleStatPercentPowerUpData", menuName = "Mighty Adventures/Power Ups/Simple Stat Percent Power Up")]
    public class SimpleStatPercentPowerUpData : AbstractPowerUpData
    {
        [SerializeField] private SimpleStatTypes statType;
        [SerializeField, Range(0.1f, 100f)] private float statIncreasePercent;

        public override void ApplyPowerUp(PlayerCharacterStats stats)
        {
            var simpleStat = GetStat();
            var increaseAmount = simpleStat.Value * statIncreasePercent / 100f;
            simpleStat.ChangeValue(increaseAmount);

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
            return $"<color=#{colorHex}>{statType}</color> increased by {statIncreasePercent}%";
        }
    }
}