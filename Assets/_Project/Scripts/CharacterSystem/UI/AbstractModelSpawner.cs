using UnityEngine;

namespace MightyAdventures.CharacterSystem.UI
{
    public abstract class AbstractModelSpawner : MonoBehaviour
    {
        [SerializeField] private Transform parent;
        [SerializeField] private float modelScale;

        protected GameObject CharacterModel;
        protected void SpawnCharacterModel()
        {
            CharacterModel = Instantiate(GetModelPrefab(), parent);
            CharacterModel.transform.localScale = Vector3.one * modelScale;
        }
        
        protected abstract GameObject GetModelPrefab();
    }
}