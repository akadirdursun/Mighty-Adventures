using MightyAdventures.EnemySystem;
using MightyAdventures.StatSystem;
using UnityEngine;

namespace MightyAdventures.HUD
{
    public class EnemyCharacterInfoAreaController: AbstractCharacterInfoAreaController
    {
        [SerializeField, Space] private SpawnedEnemyData spawnedEnemyData;
        protected override CharacterStats GetCharacterStats()
        {
            return spawnedEnemyData.Stats;
        }

        protected override string GetCharacterName()
        {
            return spawnedEnemyData.Name;
        }

        private void OnNewEnemySpawned()
        {
            Initialize();
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