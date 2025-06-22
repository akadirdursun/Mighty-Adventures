using MightyAdventures.StatSystem;
using MightyAdventures.StatSystem.UI;
using TMPro;
using UnityEngine;

namespace MightyAdventures.HUD
{
    public abstract class AbstractCharacterInfoAreaController : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameText;
        [Header("Stat Views")]
        [SerializeField] private VitalStatView healthTextView;
        [SerializeField] private StatTextView healthRegenTextView;
        [SerializeField] private StatTextView damageResistanceTextView;
        [SerializeField] private StatTextView damageTextView;

        protected void Initialize()
        {
            var characterStats = GetCharacterStats();
            nameText.text = GetCharacterName();
            healthTextView.Initialize(characterStats.Health);
            damageResistanceTextView.Initialize("Damage Resistance", characterStats.DamageResistance);
            damageTextView.Initialize("Damage", characterStats.Damage);
            SetExtraAreas();
        }

        protected virtual void SetExtraAreas()
        {
        }
        
        protected abstract CharacterStats GetCharacterStats();
        protected abstract string GetCharacterName();
    }
}