using System;
using MightyAdventures.StatSystem;
using UnityEngine;

namespace MightyAdventures.CharacterSystem
{
    [CreateAssetMenu(fileName = "PlayerCharacterData", menuName = "Mighty Adventures/Character System/Player Character Data")]
    public class PlayerCharacterData : ScriptableObject
    {
        [SerializeField] private PlayerCharacterExperienceData experienceData;
        [SerializeField, Space] private string characterName;
        [SerializeField] private int level = 1;
        [SerializeField] private float experience;
        [SerializeField] private PlayerCharacterStats stats;
        private PlayerCharacterTemplate _template;
        private float _targetExperience;
        public string Name => characterName;
        public int Level => level;
        public float TargetExperience => _targetExperience;
        public float CurrentExperience => experience;
        public GameObject CharacterPrefab => _template.Prefab;
        public PlayerCharacterStats Stats => stats;
        public Action OnCharacterLevelChanged;
        public Action OnCharacterExperienceChanged;
        public Action OnCharacterInitialized;

        public void InitializePlayerCharacter()
        {
            characterName = _template.CharacterName;
            stats = _template.PlayerCharacterStats.Clone();
            level = 1;
            experience = 0;
            SetTargetExperience();
            OnCharacterInitialized?.Invoke();
        }
        
        public void InitializePlayerCharacter(PlayerCharacterTemplate template)
        {
            _template = template;
            InitializePlayerCharacter();
        }

        public void AddExperience(float experienceToAdd)
        {
            experience += experienceToAdd;
            OnCharacterExperienceChanged?.Invoke();
            while (experience >= _targetExperience)
            {
                level++;
                experience -= _targetExperience;
                SetTargetExperience();
                OnCharacterLevelChanged?.Invoke();
            }
        }

        private void SetTargetExperience()
        {
            var targetLevel = level + 1;
            _targetExperience = experienceData.GetExperienceCost(targetLevel);
        }

        public void Damage(float damageTaken)
        {
            var resistanceAmount = damageTaken * stats.DamageResistance.PercentValue;
            stats.Health.DecreaseCurrentValue(damageTaken - resistanceAmount);
        }
    }
}