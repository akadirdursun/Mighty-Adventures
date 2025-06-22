using System;
using UnityEngine;

namespace MightyAdventures.StatSystem
{
    [Serializable]
    public class PercentileStat : AbstractStat
    {
        #region Constructor

        public PercentileStat(float value)
        {
            this.value = value;
        }

        #endregion
        
        [SerializeField, Range(0f, 95f)] private float value;
        private const float MaxPercentage = 95f;
        public override float Value => value;

        public void ChangeValue(float changeAmount)
        {
            value = Mathf.Clamp(value + changeAmount, 0f, MaxPercentage);
            OnStatChanged?.Invoke();
        }

        public override string GetValueText()
        {
            return $"{value:F2}%";
        }

        public PercentileStat Clone()
        {
            return new PercentileStat(Value);
        }
    }
}