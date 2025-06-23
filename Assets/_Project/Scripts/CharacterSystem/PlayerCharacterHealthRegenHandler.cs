using System.Collections;
using MightyAdventures.StatSystem;
using UnityEngine;

namespace MightyAdventures.CharacterSystem
{
    public class PlayerCharacterHealthRegenHandler : MonoBehaviour
    {
        [SerializeField] protected PlayerCharacterData playerCharacterData;

        private Coroutine _healthRegenCoroutine;
        private VitalityStat _characterHealthStat;

        private void OnCharacterHealthChanged()
        {
            if (_healthRegenCoroutine != null)
            {
                StopCoroutine(_healthRegenCoroutine);
                _healthRegenCoroutine = null;
            }

            if(_characterHealthStat.IsFull) return;
            _healthRegenCoroutine = StartCoroutine(HealthRegenRoutine());
        }

        private IEnumerator HealthRegenRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                _characterHealthStat.RegenVitality();
            }
        }

        #region MonoBehaviour Methods

        private void Awake()
        {
            _characterHealthStat = playerCharacterData.PlayerCharacterStats.Health;
        }

        private void OnEnable()
        {
            _characterHealthStat.OnStatChanged += OnCharacterHealthChanged;
        }

        private void OnDisable()
        {
            _characterHealthStat.OnStatChanged -= OnCharacterHealthChanged;
        }

        #endregion
    }
}