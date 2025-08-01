﻿using System;
using UnityEngine;

namespace MightyAdventures.StatSystem
{
    [Serializable]
    public class VitalityStat : AbstractStat
    {
        #region Constructors

        public VitalityStat(float maxValue, float regenRate)
        {
            this.maxValue = maxValue;
            this.regenRate = regenRate;
            _currentValue = this.maxValue;
        }

        #endregion

        [SerializeField] private float maxValue;
        [SerializeField] private float regenRate;
        private float _currentValue;
        public override float Value => _currentValue;
        public float MaxValue => maxValue;
        public bool IsFull => _currentValue == maxValue;
        public float RegenRage => regenRate;
        public Action OnVitalDropToZero;

        public void IncreaseMaxValue(float additionValue)
        {
            maxValue += additionValue;
            _currentValue = Mathf.Clamp(_currentValue + additionValue, 0, maxValue);
            OnStatChanged?.Invoke();
        }

        public void DecreaseMaxValue(float removedValue)
        {
            maxValue -= removedValue;
            _currentValue = Mathf.Clamp(_currentValue, 0, maxValue);
            OnStatChanged?.Invoke();
        }

        public void IncreaseCurrentValue(float additionValue)
        {
            _currentValue = Mathf.Clamp(_currentValue + additionValue, 0, maxValue);
            OnStatChanged?.Invoke();
        }

        public void DecreaseCurrentValue(float removedValue)
        {
            _currentValue = Mathf.Clamp(_currentValue - removedValue, 0, maxValue);
            OnStatChanged?.Invoke();
            if (_currentValue > 0) return;
            OnVitalDropToZero?.Invoke();
        }

        public void RegenVitality()
        {
            IncreaseCurrentValue(regenRate);
        }

        public void IncreaseRegenRate(float increaseAmount)
        {
            regenRate += increaseAmount;
            OnStatChanged?.Invoke();
        }

        public override string GetValueText()
        {
            return $"{_currentValue:F0}/ {maxValue:F0}";
        }

        public VitalityStat Clone()
        {
            return new VitalityStat(maxValue, regenRate);
        }
    }
}