using UnityEngine;

namespace MightyAdventures.CharacterSystem.UI
{
    public class PlayerCharacterModelSpawner : AbstractModelSpawner
    {
        [SerializeField] private PlayerCharacterData playerCharacterData;
        protected override GameObject GetModelPrefab()
        {
            return playerCharacterData.CharacterPrefab;
        }
        
        #region MonoBehaviour Methods

        private void Start()
        {
            SpawnCharacterModel();
        }

        #endregion
    }
}