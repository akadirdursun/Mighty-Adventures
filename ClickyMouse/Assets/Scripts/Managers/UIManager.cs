using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

namespace ClickyMause
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;
        [Header("UI")]
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private GameObject gameOverScreen;
        [SerializeField] private GameObject titleScreen;
        [SerializeField] private GameObject hud;
        [SerializeField] private GameObject TargetInfoButton;
        [Header("Pause UI")]
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private Button pauseButton;
        [Header("Health UI")]
        [SerializeField] private GameObject healthUIParent;
        [SerializeField] private TextMeshProUGUI healthValueText;
        [SerializeField] private Slider healthSlider;

        private bool isHungry;
        private bool isPaused;

        private void Awake()
        {
            playerData.UiManager = this;
        }

        private void OnEnable()
        {
            StaticEvents.StartTheGame += CloseTitleScreen;
            StaticEvents.GameOver += OpenGameOverUI;
            StaticEvents.Hungry += ShowHealthUI;
            StaticEvents.PauseResumeGame += OpenClosePauseMenu;
        }

        private void OnDisable()
        {
            StaticEvents.StartTheGame -= CloseTitleScreen;
            StaticEvents.GameOver -= OpenGameOverUI;
            StaticEvents.Hungry -= ShowHealthUI;
            StaticEvents.PauseResumeGame -= OpenClosePauseMenu;
        }

        private void OpenGameOverUI()
        {
            gameOverScreen.SetActive(true);
        }

        private void CloseTitleScreen(DifficultySettingsData settings)
        {
            titleScreen.SetActive(false);
            TargetInfoButton.SetActive(false);
            hud.SetActive(true);
        }

        private void ShowHealthUI(bool value)
        {
            isHungry = value;
            healthUIParent.SetActive(value);
        }

        public void UpdateScoreUI()
        {
            scoreText.text = playerData.Score.ToString();
        }

        public void UpdateHealthUI()
        {
            if (!healthUIParent.activeInHierarchy)
                StartCoroutine(ShowHealthUICoroutine());

            healthValueText.text = playerData.CurrentHealth + " / " + playerData.MaxHealth;
            healthSlider.maxValue = playerData.MaxHealth;
            healthSlider.value = playerData.CurrentHealth;
        }

        public void OpenClosePauseMenu()
        {
            if (isPaused)
            {
                pauseMenu.SetActive(false);
                isPaused = false;
                pauseButton.gameObject.SetActive(true);
            }
            else
            {
                pauseMenu.SetActive(true);
                isPaused = true;
                pauseButton.gameObject.SetActive(false);
            }

        }

        IEnumerator ShowHealthUICoroutine()
        {
            healthUIParent.SetActive(true);
            yield return new WaitForSeconds(1f);
            if (!isHungry)
                healthUIParent.SetActive(false);
        }
    }
}