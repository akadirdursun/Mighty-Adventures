using System;
using MightyAdventures.GameStateSystem;
using UnityEngine;

namespace MightyAdventures.CharacterSystem
{
    public class PlayerLevelUpHandler : MonoBehaviour
    {
        [SerializeField] private PlayerCharacterData playerCharacterData;
        [SerializeField] private GameStateData gameStateData;

        private void OnPlayerLevelUp()
        {
            gameStateData.ChangeGameState(GameStates.LevelUpState);
        }

        #region MonoBehaviour Methods

        private void OnEnable()
        {
            playerCharacterData.OnCharacterLevelUp += OnPlayerLevelUp;
        }

        private void OnDisable()
        {
            playerCharacterData.OnCharacterLevelUp -= OnPlayerLevelUp;
        }

        #endregion
    }
}