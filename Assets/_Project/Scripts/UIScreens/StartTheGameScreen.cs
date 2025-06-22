using MightyAdventures.GameStateSystem;
using UnityEngine;
using UnityEngine.UI;

namespace MightyAdventures.UIScreens
{
    public class StartTheGameScreen : AbstractUIScreen
    {
        [SerializeField] private GameStateData gameStateData;
        [SerializeField] private Button startGameButton;

        private void OnStartGameButtonClicked()
        {
            gameStateData.ChangeGameState(GameStates.CombatState);
            Hide();
        }

        #region MonoBehaviour Methods

        private void OnEnable()
        {
            startGameButton.onClick.AddListener(OnStartGameButtonClicked);
        }

        private void OnDisable()
        {
            startGameButton.onClick.RemoveListener(OnStartGameButtonClicked);
        }

        #endregion
    }
}