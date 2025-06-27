using System;
using MightyAdventures.EnemySystem;
using MightyAdventures.StatSystem;
using UnityEngine;

namespace MightyAdventures.CharacterSystem
{
    [CreateAssetMenu(fileName = "PlayerCharacterBehaviour", menuName = "Mighty Adventures/Character System/Player Character Behaviour")]
    public class PlayerCharacterBehaviour : ScriptableObject
    {
        [SerializeField] private PlayerCharacterData playerCharacterData;
        [SerializeField] private PlayerCharacterExperienceData experienceData;
        [SerializeField] private SpawnedEnemyData spawnedEnemyData;
        public Action OnPerformBasicAttack;
        public Action OnPerformHeavyAttack;
        public Action OnDamaged;
        public Action OnHealed;
        public Action OnDied;
        public Action OnGainExperience;
        public Action OnLevelUp;

        private PlayerCharacterStats Stats => playerCharacterData.Stats;

        public void ReviveCharacter()
        {
            playerCharacterData.InitializePlayerCharacter(GetTargetExperience(1));
        }

        public void Damage(float damageTaken)
        {
            var damageResistanceStat = Stats.DamageResistance;
            var resistanceAmount = damageTaken * damageResistanceStat.PercentValue;
            Stats.Health.DecreaseCurrentValue(damageTaken - resistanceAmount);
            OnDamaged?.Invoke();
            if (Stats.Health.Value > 0) return;
            OnDied?.Invoke();
        }

        public void Heal()
        {
            if (Stats.Health.IsFull) return;
            Stats.Health.RegenVitality();
            OnHealed?.Invoke();
        }
        
        public void Heal(float healAmount)
        {
            if (Stats.Health.IsFull) return;
            Stats.Health.IncreaseCurrentValue(healAmount);
            OnHealed?.Invoke();
        }

        public void AddExperience(float experienceToAdd)
        {
            var currentExperience = playerCharacterData.CurrentExperience;
            var newTotalExperience = currentExperience + experienceToAdd;
            if (newTotalExperience >= playerCharacterData.TargetExperience)
            {
                newTotalExperience -= playerCharacterData.TargetExperience;
                playerCharacterData.LevelUp();
                playerCharacterData.SetTargetExperience(GetTargetExperience(playerCharacterData.Level));
                OnLevelUp?.Invoke();
            }

            playerCharacterData.SetExperience(newTotalExperience);
            OnGainExperience?.Invoke();
        }
        
        public void PerformBasicAttackSkill(float damage)
        {
            DamageSpawnedEnemy(damage);
            OnPerformBasicAttack?.Invoke();
        }

        public void PerformHeavyAttackSkill(float damage)
        {
            DamageSpawnedEnemy(damage);
            OnPerformHeavyAttack?.Invoke();
        }

        private float GetTargetExperience(int currentLevel)
        {
            var targetLevel = currentLevel + 1;
            return experienceData.GetExperienceCost(targetLevel);
        }

        private void DamageSpawnedEnemy(float damage)
        {
            spawnedEnemyData.Damage(damage);
        }
    }
}