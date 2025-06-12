    using MightyAdventures.CharacterSystem;
using MightyAdventures.StatSystem.UI;
using UnityEngine;

namespace MightyAdventures.HUD
{
    public class PlayerCharacterAreaController : MonoBehaviour
    {
        [SerializeField] private PlayerCharacterData playerCharacterData;
        [SerializeField] private StatTextView healthTextView;
        [SerializeField] private StatTextView healthRegenTextView;
        [SerializeField] private StatTextView damageResistanceTextView;
        [SerializeField] private StatTextView damageTextView;

        private void Initialize()
        {
            var characterStats = playerCharacterData.CharacterStats;
            healthTextView.Initialize("Health", characterStats.Health);
            healthRegenTextView.Initialize("Health Regen", characterStats.HealthRegen, "/s");
            damageResistanceTextView.Initialize("Damage Resistance", characterStats.DamageResistance, "%");
            damageTextView.Initialize("Damage", characterStats.Damage);
        }

        #region MonoBehaviour Methods

        private void Start()
        {
            Initialize();
        }

        #endregion
    }
}