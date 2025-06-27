using System;
using MightyAdventures.GameStateSystem;
using UnityEngine;

namespace MightyAdventures.CharacterSystem
{
    public class PlayerLevelUpHandler : MonoBehaviour
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