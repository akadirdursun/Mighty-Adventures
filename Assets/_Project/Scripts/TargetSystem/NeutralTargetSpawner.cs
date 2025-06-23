using System.Collections;
using MightyAdventures.CharacterSystem;
using MightyAdventures.GameZone;
using MightyAdventures.SpawnSystem;
using UnityEngine;

namespace MightyAdventures.TargetSystem
{
    public class NeutralTargetSpawner : MonoBehaviour
    {
        [SerializeField] private PlayerCharacterData playerCharacterData;
        [SerializeField] private GameZoneData gameZoneData;
        [SerializeField] private AbstractTargetPoolManager targetPoolManager;
        [SerializeField] private float minSpawnTime;
        [SerializeField] private float maxSpawnTime;
        [SerializeField] private int maxSpawnCount;

        private Coroutine _spawnCoroutine;

        public void ActivateTargetSpawner()
        {
            if (_spawnCoroutine != null) return;
            _spawnCoroutine = StartCoroutine(SpawnTargetCoroutine());
        }

        public void DeactivateTargetSpawner()
        {
            if (_spawnCoroutine == null) return;
            StopCoroutine(_spawnCoroutine);
            _spawnCoroutine = null;
        }

        private void SpawnTarget()
        {
            var spawnCount = Random.Range(1, maxSpawnCount);
            for (int i = 0; i < spawnCount; i++)
            {
                var target = targetPoolManager.GetTarget();
                var spawnPos = gameZoneData.GetRandomPositionInBounds();
                target.transform.position = spawnPos;
                target.Enable();
                target.Throw();
            }
        }

        private IEnumerator SpawnTargetCoroutine()
        {
            while (true)
            {
                var cooldown = Random.Range(minSpawnTime, maxSpawnTime);
                yield return new WaitForSeconds(cooldown);
                SpawnTarget();
            }
        }
    }
}