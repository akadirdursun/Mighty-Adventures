using System;
using UnityEngine;

namespace MightyAdventures.StatSystem
{
    [Serializable]
    public class SimpleStat : AbstractStat
    {
        #region Constructors

        public SimpleStat(float value)
        {
            this.value = value;
        }

        #endregion

        [SerializeField] private float value;

        public override float Value => value;

        public void ChangeValue(float changeAmount)
        {
            value += changeAmount;
            OnStatChanged?.Invoke();
        }

        public override string GetValueText()
        {
            return $"{value:F0}";
        }

        public SimpleStat Clone()
        {
            return new SimpleStat(value);
        }
    }
}