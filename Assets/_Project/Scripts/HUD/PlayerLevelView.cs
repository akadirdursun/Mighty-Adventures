using MightyAdventures.CharacterSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MightyAdventures.HUD
{
    public class PlayerLevelView : MonoBehaviour
    {
        [SerializeField] private PlayerCharacterData playerCharacterData;
        [SerializeField] private Slider experienceSlider;
        [SerializeField] private TMP_Text levelText;
        [SerializeField] private TMP_Text experienceText;

        public void Initialize()
        {
            UpdateLevelInfo();
            UpdateExperienceView();
        }

        private void UpdateExperienceView()
        {
            experienceSlider.value = playerCharacterData.CurrentExperience;
            experienceText.text = $"{playerCharacterData.CurrentExperience:F1} / {playerCharacterData.TargetExperience:F1}";
        }

        private void UpdateLevelInfo()
        {
            levelText.text = $"Lv.{playerCharacterData.Level}";
            experienceSlider.maxValue = playerCharacterData.TargetExperience;
            UpdateExperienceView();
        }

        #region MonoBehaviour Methods

        private void OnEnable()
        {
            playerCharacterData.OnCharacterInitialized += Initialize;
            playerCharacterData.OnCharacterLevelUp += UpdateLevelInfo;
            playerCharacterData.OnCharacterExperienceChanged += UpdateExperienceView;
        }

        private void Start()
        {
            Initialize();
        }

        private void OnDisable()
        {
            playerCharacterData.OnCharacterInitialized -= Initialize;
            playerCharacterData.OnCharacterLevelUp -= UpdateLevelInfo;
            playerCharacterData.OnCharacterExperienceChanged -= UpdateExperienceView;
        }

        #endregion
    }
}