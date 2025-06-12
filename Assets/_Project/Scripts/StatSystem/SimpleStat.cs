using System;
using UnityEngine;

namespace MightyAdventures.StatSystem
{
    [Serializable]
    public class SimpleStat : AbstractStat
    {
        #region Constructors

        public SimpleStat(float value, float maxValue, bool showMaxValueOnText)
        {
            this.value = value;
            this.maxValue = maxValue;
            this.showMaxValueOnText = showMaxValueOnText;
        }

        #endregion

        [SerializeField] private float value;
        [SerializeField] private float maxValue = float.MaxValue;
        [SerializeField] private bool showMaxValueOnText;

        public override float Value => value;

        public void ChangeValue(float changeAmount)
        {
            if (Mathf.Approximately(value, maxValue)) return;
            value = Mathf.Clamp(changeAmount + value, 0, maxValue);
            OnStatChanged?.Invoke();
        }

        public override string GetValueText()
        {
            var log = $"{value:F2}";
            if (showMaxValueOnText) log += $"/ {maxValue:F2}";
            return log;
        }

        public SimpleStat Clone()
        {
            return new SimpleStat(value, maxValue, showMaxValueOnText);
        }
    }
}