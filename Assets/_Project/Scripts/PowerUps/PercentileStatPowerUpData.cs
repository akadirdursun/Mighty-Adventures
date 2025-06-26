using System;
using MightyAdventures.StatSystem;
using UnityEngine;

namespace MightyAdventures.PowerUps
{
    [CreateAssetMenu(fileName = "NewPercentileStatPowerUpData", menuName = "Mighty Adventures/Power Ups/Percentile Stat Power Up")]
    public class PercentileStatPowerUpData : AbstractPowerUpData
    {
        [SerializeField] private PercentileStatTypes statType;
        [SerializeField, Range(0.1f, 100f)] private float statIncrease;

        public override void ApplyPowerUp(PlayerCharacterStats stats)
        {
            var percentileStat = GetStat();
            percentileStat.ChangeValue(statIncrease);

            PercentileStat GetStat()
            {
                return statType switch
                {
                    PercentileStatTypes.DamageResistance => stats.DamageResistance,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
        }

        public override string GetDescription()
        {
            var colorHex = GetColorHexCode();
            return $"Increase <color=#{colorHex}>{statName}</color> by {statIncrease}%";
        }
    }
}