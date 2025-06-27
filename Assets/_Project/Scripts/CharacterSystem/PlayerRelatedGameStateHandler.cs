using MightyAdventures.GameStateSystem;
using UnityEngine;

namespace MightyAdventures.CharacterSystem
{
    public class PlayerRelatedGameStateHandler : MonoBehaviour
    {
        [SerializeField] private PlayerCharacterBehaviour playerCharacterBehaviour;
        [SerializeField] private GameStateData gameStateData;

        private void OnPlayerLevelUp()
        {
            gameStateData.ChangeGameState(GameStates.LevelUpState);
        }

        private void OnPlayerDied()
        {
            gameStateData.ChangeGameState(GameStates.DefeatState);
        }

        #region MonoBehaviour Methods

        private void OnEnable()
        {
            playerCharacterBehaviour.OnLevelUp += OnPlayerLevelUp;
            playerCharacterBehaviour.OnDied += OnPlayerDied;
        }

        private void OnDisable()
        {
            playerCharacterBehaviour.OnLevelUp -= OnPlayerLevelUp;
            playerCharacterBehaviour.OnDied -= OnPlayerDied;
        }

        #endregion
    }
}