using MightyAdventures.StatSystem;
using UnityEngine;

namespace MightyAdventures.PowerUps
{
    [CreateAssetMenu(fileName = "NewIntervalStatPowerUpData", menuName = "Mighty Adventures/Power Ups/Interval Stat Power Up")]
    public class IntervalStatPowerUpData : AbstractPowerUpData
    {
        [SerializeField] private IntervalStatTypes statType;
        [SerializeField, Range(1, 100)] private int minIncrease = 1;
        [SerializeField, Range(1, 100)] private int maxIncrease = 1;

        private int _minValueIncrease;
        private int _maxValueIncrease;

        public override void ApplyPowerUp(PlayerCharacterStats stats)
        {
            var intervalStat = GetStat();
            intervalStat.ChangeValue(_minValueIncrease, _maxValueIncrease);

            IntervalStat GetStat()
            {
                return statType switch
                {
                    IntervalStatTypes.Damage => stats.Damage,
                    _ => stats.Damage
                };
            }
        }

        private void LockTheValues()
        {
            _maxValueIncrease = Random.Range(minIncrease, maxIncrease + 1);
            _minValueIncrease = Random.Range(minIncrease, _maxValueIncrease + 1);
        }

        public override string GetDescription()
        {
            LockTheValues();
            var statColorHex = GetColorHexCode();
            return $"Increase <color=#{statColorHex}>{statName}</color> by {_minValueIncrease} ~ {_maxValueIncrease}";
        }
    }
}