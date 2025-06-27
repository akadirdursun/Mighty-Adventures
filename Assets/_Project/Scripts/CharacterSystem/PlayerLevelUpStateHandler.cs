using MightyAdventures.GameStateSystem;
using UnityEngine;

namespace MightyAdventures.CharacterSystem
{
    public class PlayerLevelUpStateHandler : MonoBehaviour
    {
        [SerializeField] private PlayerCharacterBehaviour playerCharacterBehaviour;
        [SerializeField] private GameStateData gameStateData;

        private void OnPlayerLevelUp()
        {
            gameStateData.ChangeGameState(GameStates.LevelUpState);
        }

        #region MonoBehaviour Methods

        private void OnEnable()
        {
            playerCharacterBehaviour.OnLevelUp += OnPlayerLevelUp;
        }

        private void OnDisable()
        {
            playerCharacterBehaviour.OnLevelUp -= OnPlayerLevelUp;
        }

        #endregion
    }
}