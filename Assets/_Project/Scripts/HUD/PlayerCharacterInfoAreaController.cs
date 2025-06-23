using MightyAdventures.CharacterSystem;
using MightyAdventures.StatSystem.UI;
using TMPro;
using UnityEngine;

namespace MightyAdventures.HUD
{
    public class PlayerCharacterInfoAreaController : MonoBehaviour
    {
        [SerializeField, Space] private PlayerCharacterData playerCharacterData;
        [SerializeField] private TMP_Text nameText;
        [Header("Stat Views")]
        [SerializeField] private VitalStatView healthView;
        [SerializeField] private RoundStatView damageView;
        [SerializeField] private RoundStatView damageResistanceView;
        [SerializeField] private StatTextView attackSpeedView;
        [SerializeField] private StatTextView attackTokenCount;

        private void Initialize()
        {
            nameText.text = playerCharacterData.Name;
            var characterStats = playerCharacterData.PlayerCharacterStats;
            healthView.Initialize(characterStats.Health);
            damageView.Initialize(characterStats.Damage);
            ;
            damageResistanceView.Initialize(characterStats.DamageResistance);
            attackSpeedView.Initialize("Attack Speed", characterStats.AttackSpeed, "s");
            attackTokenCount.Initialize("Attack Token Spawn Count", characterStats.MaxSkillTokenCount);
        }

        #region MonoBehaviour Methods

        private void Start()
        {
            Initialize();
        }

        #endregion
    }
}