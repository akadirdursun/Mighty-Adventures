using UnityEngine;

namespace MightyAdventures.InputSystem
{
    [CreateAssetMenu(fileName = "PlayerInputs", menuName = "Mighty Adventures/Input System/Player Inputs")]
    public class PlayerInputs : ScriptableObject
    {
        private InputMap _actionMap;
        private InputMap.GameplayActions _gameplayActions;

        public InputMap.GameplayActions GameplayActions => _gameplayActions;

        public void Initialize()
        {
            _actionMap = new InputMap();
            _gameplayActions = _actionMap.Gameplay;
        }

        public void EnableGameplayInputs()
        {
            _gameplayActions.Enable();
        }

        public void DisableGameplayInputs()
        {
            _gameplayActions.Disable();
        }
    }
}