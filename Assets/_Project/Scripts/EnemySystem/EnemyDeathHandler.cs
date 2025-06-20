
using MightyAdventures.CharacterSystem;
using UnityEngine;

namespace MightyAdventures.EnemySystem
{
    public class EnemyDeathHandler : MonoBehaviour
    {
        [SerializeField] private SpawnedEnemyData spawnedEnemyData;
        [SerializeField] private PlayerCharacterData playerCharacterData;
        [SerializeField] private EnemySpawner enemySpawner;

        private void OnNewEnemySpawned()
        {
            spawnedEnemyData.Stats.Health.OnStatChanged += OnEnemyHealthChanged;
        }

        private void OnEnemyHealthChanged()
        {
            if (spawnedEnemyData.IsAlive) return;
            playerCharacterData.AddExperience(spawnedEnemyData.Experience);
            enemySpawner.SpawnEnemy();
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