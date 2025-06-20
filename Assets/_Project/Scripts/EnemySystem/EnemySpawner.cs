using System.Linq;
using MightyAdventures.CharacterSystem;
using MightyAdventures.Utilities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MightyAdventures.EnemySystem
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private PlayerCharacterData playerCharacterData;
        [SerializeField] private SpawnedEnemyData spawnedEnemyData;
        [SerializeField] private EnemyTemplate[] enemyTemplates;

        public void SpawnEnemy()
        {
            var maxLevel = playerCharacterData.Level;
            var level = Random.Range(1, maxLevel + 1);
            var possibleEnemies = enemyTemplates.Where(template => template.IsAvailableToSpawn(info => info.level == level)).ToArray();
            var selectedEnemy = possibleEnemies.Random();
            selectedEnemy.TryGetLevelInfo(level, out var levelInfo);
            spawnedEnemyData.Initialize(selectedEnemy.Name, level, levelInfo.experience, levelInfo.stats.Clone(), selectedEnemy.Prefab);
        }

        #region MonoBehaviour Methods

        private void Start()
        {
            SpawnEnemy();
        }

        #endregion
    }
}