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
        [SerializeField] private VitalStatView healthView;
        [SerializeField] private RoundStatView damageView;
        [SerializeField] private RoundStatView damageResistanceView;
        [SerializeField] private StatTextView attackSpeedView;
        [SerializeField] private StatTextView attackTokenCount;

        protected void Initialize()
        {
            var characterStats = GetCharacterStats();
            nameText.text = GetCharacterName();
            healthView.Initialize(characterStats.Health);
            damageView.Initialize(characterStats.Damage); ;
            damageResistanceView.Initialize(characterStats.DamageResistance);
            attackSpeedView.Initialize("Attack Speed", characterStats.AttackSpeed);
            attackTokenCount.Initialize("Attack Token Count", characterStats.MaxSkillTokenCount);
        }
        
        protected abstract PlayerCharacterStats GetCharacterStats();
        protected abstract string GetCharacterName();
    }
}