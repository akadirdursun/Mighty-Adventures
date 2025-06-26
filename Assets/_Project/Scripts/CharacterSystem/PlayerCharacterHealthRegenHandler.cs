using System.Collections;
using MightyAdventures.StatSystem;
using UnityEngine;

namespace MightyAdventures.CharacterSystem
{
    public class PlayerCharacterHealthRegenHandler : MonoBehaviour
    {
        [SerializeField] protected PlayerCharacterData playerCharacterData;

        private Coroutine _healthRegenCoroutine;
        private VitalityStat _healthStat;

        public void TryToStartHealthRegen()
        {
            StopHealthRegen();
            if (_healthStat.IsFull) return;
            _healthRegenCoroutine = StartCoroutine(HealthRegenRoutine());
        }

        public void StopHealthRegen()
        {
            if (_healthRegenCoroutine == null) return;
            StopCoroutine(_healthRegenCoroutine);
            _healthRegenCoroutine = null;
        }

        private IEnumerator HealthRegenRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                _healthStat.RegenVitality();
            }
        }

        private void SetCharacterHealthStat()
        {
            UnregisterFromHealthEvents();
            _healthStat = playerCharacterData.Stats.Health;
            RegisterToHealthEvents();
        }

        private void RegisterToHealthEvents()
        {
            if (_healthStat == null) return;
            _healthStat.OnStatChanged += TryToStartHealthRegen;
            _healthStat.OnVitalDropToZero += StopHealthRegen;
        }

        private void UnregisterFromHealthEvents()
        {
            if (_healthStat == null) return;
            _healthStat.OnStatChanged -= TryToStartHealthRegen;
            _healthStat.OnVitalDropToZero -= StopHealthRegen;
        }

        #region MonoBehaviour Methods

        private void Awake()
        {
            SetCharacterHealthStat();
        }

        private void OnEnable()
        {
            playerCharacterData.OnCharacterInitialized += SetCharacterHealthStat;
        }

        private void OnDisable()
        {
            playerCharacterData.OnCharacterInitialized -= SetCharacterHealthStat;
            UnregisterFromHealthEvents();
        }

        #endregion
    }
}