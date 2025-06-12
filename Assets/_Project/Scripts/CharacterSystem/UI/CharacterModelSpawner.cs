using UnityEngine;

namespace MightyAdventures.CharacterSystem.UI
{
    public class CharacterModelSpawner : MonoBehaviour
    {
        [SerializeField] private PlayerCharacterData playerCharacterData;
        [SerializeField] private Transform parent;
        [SerializeField] private float modelScale;

        private void Initialize()
        {
            var model = Instantiate(playerCharacterData.CharacterPrefab, parent);
            model.transform.localScale = Vector3.one * modelScale;
        }

        #region MonoBehaviour Methods

        private void Start()
        {
            Initialize();
        }

        #endregion
    }
}