using TMPro;
using UnityEngine;

namespace MightyAdventures.StatSystem.UI
{
    public class StatTextPreview : MonoBehaviour
    {
        [SerializeField] private TMP_Text statInfoText;

        public void Initialize(PlayerCharacterStats playerCharacterStats)
        {
            statInfoText.text = $"Health: {playerCharacterStats.Health.GetValueText()}" +
                                $"\nDamage Resistance: {playerCharacterStats.DamageResistance.GetValueText()}" +
                                $"\nDamage: {playerCharacterStats.Damage.GetValueText()}";
        }
    }
}