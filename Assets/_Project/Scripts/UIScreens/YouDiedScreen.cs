using MightyAdventures.GameStateSystem;
using MightyAdventures.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace MightyAdventures.UIScreens
{
    public class YouDiedScreen : AbstractUIScreen
    {
        [SerializeField] private GameStateData gameStateData;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button mainMenuButton;

        private void OnRestartButtonClicked()
        {
            gameStateData.ChangeGameState(GameStates.IdleState);
            Hide();
        }

        private void OnMainMenuButtonClicked()
        {
            SceneLoader.Instance.ReturnToMainMenu();
        }

        #region MonoBehaviour Methods

        private void OnEnable()
        {
            restartButton.onClick.AddListener(OnRestartButtonClicked);
            mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
        }

        private void OnDisable()
        {
            restartButton.onClick.RemoveListener(OnRestartButtonClicked);
            mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClicked);
        }

        #endregion
    }
}