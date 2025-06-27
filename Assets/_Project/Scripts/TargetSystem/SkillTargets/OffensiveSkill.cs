using MightyAdventures.CharacterSystem;
using MightyAdventures.EnemySystem;
using UnityEngine;
using UnityEngine.Events;

namespace MightyAdventures.TargetSystem.SkillTargets
{
    public class OffensiveSkill : AbstractTarget
    {
        [SerializeField] private PlayerCharacterData playerCharacterData;
        [SerializeField] private SpawnedEnemyData spawnedEnemyData;
        [SerializeField] private float damageMultiplier = 1f;
        [SerializeField, Range(0f, 1f)] private float criticalChance;
        [SerializeField] private UnityEvent<float> onHit;

        private const float CriticalDamageMultiplier = 2f;

        public override void OnHit()
        {
            base.OnHit();
            var isCritical = Random.Range(0f, 1f) <= criticalChance;
            var baseDamage = playerCharacterData.Stats.Damage.Value;
            var damage = baseDamage * damageMultiplier;
            if (isCritical)
            {
                damage *= CriticalDamageMultiplier;
            }
            onHit?.Invoke(damage);
        }
    }
}