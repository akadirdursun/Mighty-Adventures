using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClickyMause.Targets
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private ObjectPool targetPool;
        //[SerializeField] private List<GameObject> targets;
        [SerializeField] private int spawnPerSec = 5;

        private float xSpawnRange = 4f;
        private float ySpawnPos = -2f;

        private Coroutine spawnCoroutine;

        private void OnEnable()
        {
            StaticEvents.StartTheGame += StartToSpawn;
            StaticEvents.GameOver += StopSpawning;
        }

        private void OnDisable()
        {
            StaticEvents.StartTheGame -= StartToSpawn;
            StaticEvents.GameOver -= StopSpawning;
        }

        private void StartToSpawn(DifficultySettingsData settings)
        {
            spawnPerSec = settings.SpawnTime;
            spawnCoroutine = StartCoroutine(SpawnTarget());
        }

        IEnumerator SpawnTarget()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f / spawnPerSec);
                var target = targetPool.GetRandomPoolObject();                
                target.transform.position = RandomSpawnPosition();
                target.SetActive(true);
            }
        }

        private Vector3 RandomSpawnPosition()
        {
            return new Vector3(Random.Range(-xSpawnRange, xSpawnRange), ySpawnPos);
        }

        private void StopSpawning()
        {
            StopCoroutine(spawnCoroutine);
        }
    }
}