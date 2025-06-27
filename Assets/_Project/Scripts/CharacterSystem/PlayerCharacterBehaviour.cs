using System;
using MightyAdventures.StatSystem;
using UnityEngine;

namespace MightyAdventures.CharacterSystem
{
    [CreateAssetMenu(fileName = "PlayerCharacterBehaviour", menuName = "Mighty Adventures/Character System/Player Character Behaviour")]
    public class PlayerCharacterBehaviour : ScriptableObject
    {
        [SerializeField] private PlayerCharacterData playerCharacterData;
        public Action PerformedBasicAttack;
        public Action PerformedHeavyAttack;
        public Action OnDamaged;
        public Action Died;

        private PlayerCharacterStats Stats => playerCharacterData.Stats;

        public void Damage(float damageTaken)
        {
            var damageResistanceStat = Stats.DamageResistance;
            var resistanceAmount = damageTaken * damageResistanceStat.PercentValue;
            Stats.Health.DecreaseCurrentValue(damageTaken - resistanceAmount);
            OnDamaged?.Invoke();
        }
    }
}