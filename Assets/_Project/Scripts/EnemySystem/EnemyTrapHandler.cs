using System.Collections;
using MightyAdventures.GameZone;
using MightyAdventures.SpawnSystem;
using UnityEngine;

namespace MightyAdventures.EnemySystem
{
    public class EnemyTrapHandler : MonoBehaviour
    {
        [SerializeField] private SpawnedEnemyData spawnedEnemyData;
        [SerializeField] private GameZoneData gameZoneData;
        [SerializeField] private AbstractTargetPoolManager trapPoolManager;

        private Coroutine _spawnTrapCoroutine;
        private const float TrapCooldown = 1f;

        private void StartTrapSpawning()
        {
            if (_spawnTrapCoroutine != null)
            {
                StopCoroutine(_spawnTrapCoroutine);
                _spawnTrapCoroutine = null;
            }

            if (spawnedEnemyData.Stats.MaxTrapSpawnCount.Value == 0) return;

            _spawnTrapCoroutine = StartCoroutine(SpawnTrapRoutine());
        }

        private IEnumerator SpawnTrapRoutine()
        {
            var spawnChance = spawnedEnemyData.Stats.TrapSpawnChance.Value;
            var spawnCount = spawnedEnemyData.Stats.MaxTrapSpawnCount.Value;
            while (true)
            {
                yield return new WaitForSeconds(TrapCooldown);
                var rn = Random.Range(0, 100);
                if (rn > spawnChance) continue;
                for (int i = 0; i < spawnCount; i++)
                {
                    var target = trapPoolManager.GetTarget();
                    var spawnPos = gameZoneData.GetRandomPositionInBounds();
                    target.transform.position = spawnPos;
                    target.Enable();
                    target.Throw();
                }
            }
        }

        #region MonoBehaviour Methods

        private void OnEnable()
        {
            spawnedEnemyData.OnSpawnedEnemyChanged += StartTrapSpawning;
        }

        private void OnDisable()
        {
            spawnedEnemyData.OnSpawnedEnemyChanged -= StartTrapSpawning;
        }

        #endregion
    }
}