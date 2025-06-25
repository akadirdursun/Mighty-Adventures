using MightyAdventures.StatSystem;
using UnityEngine;

namespace MightyAdventures.PowerUps
{
    [CreateAssetMenu(fileName = "NewVitalityStatPowerUpData", menuName = "Mighty Adventures/Power Ups/Vitality Stat Power Up")]
    public class VitalityStatAbstractPowerUpData : AbstractPowerUpData
    {
        [SerializeField] private VitalityStatTypes statType;
        [SerializeField, Range(0f, 100f)] private float vitalityPercentIncrease;
        [SerializeField] private float vitalityRegenIncrease;

        public override void ApplyPowerUp(PlayerCharacterStats stats)
        {
            var vitalityStat = GetVitalityStat();
            var currentVitality = vitalityStat.Value;
            var increaseAmount = currentVitality * vitalityRegenIncrease / 100f;
            vitalityStat.IncreaseMaxValue(increaseAmount);
            vitalityStat.IncreaseRegenRate(vitalityRegenIncrease);

            VitalityStat GetVitalityStat()
            {
                switch (statType)
                {
                    case VitalityStatTypes.Health:
                        return stats.Health;
                    default:
                        return stats.Health;
                }
            }
        }

        public override string GetDescription()
        {
            var statColorHex = GetColorHexCode();
            return $"Increase <color=#{statColorHex}>{statName}</color> by %{vitalityPercentIncrease} and <color=#{statColorHex}>regeneration</color> by {vitalityRegenIncrease:F1}";
        }
    }
}