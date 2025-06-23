using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MightyAdventures.StatSystem
{
    [Serializable]
    public class IntervalStat : AbstractStat
    {
        #region Constructors

        public IntervalStat(float minValue, float maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        #endregion

        [SerializeField] private float minValue;
        [SerializeField] private float maxValue;

        public override float Value => Random.Range(minValue, maxValue);

        public override string GetValueText()
        {
            return $"{minValue:F0} ~ {maxValue:F0}";
        }

        public IntervalStat Clone()
        {
            return new IntervalStat(minValue, maxValue);
        }
    }
}