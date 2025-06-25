using System.Collections;
using MightyAdventures.StatSystem;
using UnityEngine;

namespace MightyAdventures.EnemySystem
{
    public class EnemyHealthRegenHandler : MonoBehaviour
    {
        [SerializeField] protected SpawnedEnemyData spawnedEnemyData;

        private Coroutine _healthRegenCoroutine;
        private VitalityStat _enemyHealthStat;

        private void OnCharacterHealthChanged()
        {
            StopHealthRegenRoutine();

            if (_enemyHealthStat.IsFull) return;
            _healthRegenCoroutine = StartCoroutine(HealthRegenRoutine());
        }

        private IEnumerator HealthRegenRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                _enemyHealthStat.RegenVitality();
            }
        }

        private void StopHealthRegenRoutine()
        {
            if (_healthRegenCoroutine == null) return;
            StopCoroutine(_healthRegenCoroutine);
            _healthRegenCoroutine = null;
        }

        private void OnNewEnemySpawned()
        {
            UnregisterFromEvents();
            _enemyHealthStat = spawnedEnemyData.Stats.Health;
            RegisterToEvents();
        }

        private void RegisterToEvents()
        {
            if (_enemyHealthStat == null) return;
            _enemyHealthStat.OnStatChanged += OnCharacterHealthChanged;
            spawnedEnemyData.OnSpawnedEnemyDied += StopHealthRegenRoutine;
        }

        private void UnregisterFromEvents()
        {
            if (_enemyHealthStat == null) return;
            _enemyHealthStat.OnStatChanged -= OnCharacterHealthChanged;
            spawnedEnemyData.OnSpawnedEnemyDied -= StopHealthRegenRoutine;
        }

        #region MonoBehaviour Methods

        private void OnEnable()
        {
            spawnedEnemyData.OnSpawnedEnemyChanged += OnNewEnemySpawned;
        }

        private void OnDisable()
        {
            spawnedEnemyData.OnSpawnedEnemyChanged -= OnNewEnemySpawned;
        }

        #endregion
    }
}