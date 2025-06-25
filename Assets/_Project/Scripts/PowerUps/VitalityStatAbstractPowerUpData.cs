using System;
using MightyAdventures.StatSystem;
using UnityEngine;

namespace MightyAdventures.PowerUps
{
    [CreateAssetMenu(fileName = "NewVitalityStatPowerUpData", menuName = "Mighty Adventures/Power Ups/Vitality Stat Power Up")]
    public class VitalityStatAbstractPowerUpData : AbstractPowerUpData
    {
        [SerializeField] private VitalityStatTypes statType;
        [SerializeField, Range(0f, 100f)] private float statIncreasePercent;
        [SerializeField] private float regenIncrease;

        public override void ApplyPowerUp(PlayerCharacterStats stats)
        {
            var vitalityStat = GetVitalityStat();
            var currentVitality = vitalityStat.Value;
            var increaseAmount = currentVitality * statIncreasePercent / 100f;
            vitalityStat.IncreaseMaxValue(increaseAmount);
            vitalityStat.IncreaseRegenRate(regenIncrease);

            VitalityStat GetVitalityStat()
            {
                return statType switch
                {
                    VitalityStatTypes.Health => stats.Health,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
        }

        public override string GetDescription()
        {
            var statColorHex = GetColorHexCode();
            return $"Increase <color=#{statColorHex}>{statName}</color> by {statIncreasePercent}% and <color=#{statColorHex}>regeneration</color> by {regenIncrease:F1}";
        }
    }
}