using TMPro;
using UnityEngine;

namespace MightyAdventures.StatSystem.UI
{
    public class StatTextPreview: MonoBehaviour
    {
        [SerializeField] private TMP_Text statInfoText;

        public void Initialize(Stats stats)
        {
            statInfoText.text = $"Health: {stats.MaxHealth}" +
                                $"\nHealth Regen: {stats.HealthRegen}/s" +
                                $"\nDamage Resistance: {stats.DamageResistance}%" +
                                $"\nDamage: {stats.MinDamage} ~ {stats.MaxDamage}";
        }
    }
}