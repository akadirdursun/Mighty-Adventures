using MightyAdventures.CharacterSystem;
using MightyAdventures.StatSystem;
using TMPro;
using UnityEngine;

namespace MightyAdventures.HUD
{
    public class PlayerCharacterInfoAreaController : AbstractCharacterInfoAreaController
    {
        [SerializeField, Space] private PlayerCharacterData playerCharacterData;
        [SerializeField] private TMP_Text levelText;

        private void SetCharacterLevelText()
        {
            levelText.text = $"Lv.{playerCharacterData.Level}";
        }
        
        protected override void SetExtraAreas()
        {
            SetCharacterLevelText();
        }

        protected override CharacterStats GetCharacterStats()
        {
            return playerCharacterData.CharacterStats;
        }

        protected override string GetCharacterName()
        {
            return playerCharacterData.Name;
        }

        #region MonoBehaviour Methods

        private void OnEnable()
        {
            playerCharacterData.OnCharacterLevelChanged += SetCharacterLevelText;
        }

        private void Start()
        {
            Initialize();
        }

        private void OnDisable()
        {
            playerCharacterData.OnCharacterLevelChanged += SetCharacterLevelText;
        }

        #endregion
    }
}