using MightyAdventures.CharacterSystem;
using UnityEngine;

namespace MightyAdventures.TargetSystem.PositiveItems
{
    public class HealthPotion : AbstractTarget
    {
        [SerializeField] private PlayerCharacterData playerCharacterData;
        [SerializeField, Range(0f, 100f)] private float healPercent;

        private void Heal()
        {
            var healthStat = playerCharacterData.Stats.Health;
            var currentHealth = healthStat.Value;
            var healAmount = currentHealth * healPercent / 100f;
            healthStat.IncreaseCurrentValue(healAmount);
        }

        #region AbstractTarget Overrides

        public override void OnHit()
        {
            base.OnHit();
            Heal();
        }

        #endregion
    }
}