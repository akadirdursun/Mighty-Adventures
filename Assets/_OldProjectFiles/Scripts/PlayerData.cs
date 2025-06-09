using UnityEngine;

namespace ClickyMause
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Player Data")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private int score;
        [Header("Health")]
        [SerializeField] private int maxHealth;
        [SerializeField] private int currentHealth;
        [Header("Hunger")]
        [SerializeField] private int maxHunger;
        [SerializeField] private int currentHunger;

        private float healPoints = 0;

        private bool isHungry = false;

        private UIManager uiManager;

        #region Properties
        public int MaxHealth { get => maxHealth; }
        public int CurrentHealth
        {
            get => currentHealth;
            set
            {
                currentHealth = Mathf.Clamp(value, 0, maxHealth);

                uiManager.UpdateHealthUI();
            }
        }
        public int MaxHunger { get => maxHunger; }
        public int CurrentHunger
        {
            get => currentHunger;
            set
            {

                currentHunger = Mathf.Clamp(value, 0, maxHunger);

                if (currentHunger == maxHunger)
                {
                    isHungry = true;
                    StaticEvents.Hungry?.Invoke(isHungry);
                }

                if (isHungry && currentHunger < maxHunger)
                {
                    isHungry = false;
                    StaticEvents.Hungry?.Invoke(isHungry);
                }
            }
        }
        public int Score { get => score; }
        public UIManager UiManager { set => uiManager = value; }
        #endregion

        private void OnEnable()
        {
            StaticEvents.StartTheGame += ResetPlayerData;
        }

        private void OnDisable()
        {
            StaticEvents.StartTheGame -= ResetPlayerData;
            isHungry = false;
        }

        private void ResetPlayerData(DifficultySettingsData d)
        {
            maxHealth = 50;
            currentHealth = maxHealth;
            currentHunger = 0;
            healPoints = 0;
            score = 0;
            isHungry = false;
        }

        public bool AddHealPoints(float hp)
        {
            healPoints += hp;
            if (healPoints >= 1)
            {
                maxHealth++;
                CurrentHealth++;
                healPoints--;
                return true;
            }
            return false;
        }

        public void AddScore(int value)
        {
            score += value;

            if (uiManager != null)
                uiManager.UpdateScoreUI();
        }
    }
}