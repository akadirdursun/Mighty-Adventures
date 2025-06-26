using MightyAdventures.CharacterSystem;
using MightyAdventures.GameStateSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MightyAdventures.PowerUps.UI
{
    public class PowerUpCard : MonoBehaviour
    {
        [SerializeField] private PlayerCharacterData playerCharacterData;
        [SerializeField] private GameStateData gameStateData;
        [SerializeField] private Image iconImage;
        [SerializeField] private TMP_Text descriptionText;
        [SerializeField] private Button selectButton;

        private AbstractPowerUpData _abstractPowerUpData;

        public void Initialize(AbstractPowerUpData abstractPowerUpData)
        {
            _abstractPowerUpData = abstractPowerUpData;
            iconImage.sprite = _abstractPowerUpData.Icon;
            descriptionText.text = _abstractPowerUpData.GetDescription();
        }

        private void OnCardSelected()
        {
            _abstractPowerUpData.ApplyPowerUp(playerCharacterData.Stats);
            gameStateData.ChangeGameState(GameStates.CombatState);
        }

        #region MonoBehaviour Methods

        private void OnEnable()
        {
            selectButton.onClick.AddListener(OnCardSelected);
        }

        private void OnDisable()
        {
            selectButton.onClick.RemoveListener(OnCardSelected);
        }

        #endregion
    }
}