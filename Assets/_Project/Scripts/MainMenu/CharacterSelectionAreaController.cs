using MightyAdventures.CharacterSystem;
using UnityEngine;

namespace MightyAdventures.MainMenu
{
    public class CharacterSelectionAreaController : MonoBehaviour
    {
        [SerializeField] private PlayerCharacterTemplate[] characterTemplates;
        [SerializeField] private CharacterSelection characterSelectionPrefab;
        [SerializeField] private Transform characterSelectionParent;

        private void Initialize()
        {
            foreach (PlayerCharacterTemplate characterTemplate in characterTemplates)
            {
                var characterSelection = Instantiate(characterSelectionPrefab, characterSelectionParent);
                characterSelection.Initialize(characterTemplate);
            }
        }

        #region MonoBehaviour Methods

        private void Start()
        {
            Initialize();
        }

        #endregion
    }
}