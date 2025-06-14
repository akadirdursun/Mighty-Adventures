using UnityEngine;

namespace MightyAdventures.SkillSystem
{
    public class OffensiveSkill : MonoBehaviour
    {
        [SerializeField] private float damageMultiplier = 1f;
        [SerializeField, Range(0f, 1f)] private float criticalChance;

        private const float CriticalDamageMultiplier = 2f;
    }
}