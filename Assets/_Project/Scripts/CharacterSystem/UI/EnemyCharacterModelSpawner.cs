using MightyAdventures.EnemySystem;
using UnityEngine;

namespace MightyAdventures.CharacterSystem.UI
{
    public class EnemyCharacterModelSpawner : AbstractModelSpawner
    {
        [SerializeField] private SpawnedEnemyData spawnedEnemyData;
        protected override GameObject GetModelPrefab()
        {
            return spawnedEnemyData.Prefab;
        }

        private void OnNewEnemySpawned()
        {
            if(CharacterModel!=null)
                Destroy(CharacterModel);
            SpawnCharacterModel();
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