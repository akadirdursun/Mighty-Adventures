using TMPro;
using UnityEngine;

namespace MightyAdventures.StatSystem.UI
{
    public class StatTextPreview : MonoBehaviour
    {
        [SerializeField] private TMP_Text statInfoText;

        public void Initialize(CharacterStats characterStats)
        {
            statInfoText.text = $"Health: {characterStats.Health.GetValueText()}" +
                                $"\nHealth Regen: {characterStats.HealthRegen.GetValueText()}/s" +
                                $"\nDamage Resistance: {characterStats.DamageResistance.GetValueText()}" +
                                $"\nDamage: {characterStats.Damage.GetValueText()}";
        }
    }
}