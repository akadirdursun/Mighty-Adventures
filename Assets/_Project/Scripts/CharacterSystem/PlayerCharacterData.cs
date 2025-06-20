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
        [SerializeField] private CharacterStats characterStats;
        private PlayerCharacterTemplate _template;
        private float _targetExperience;
        public string Name => characterName;
        public int Level => level;
        public GameObject CharacterPrefab => _template.Prefab;
        public CharacterStats CharacterStats => characterStats;
        public Action OnCharacterLevelChanged;

        public void InitializePlayerCharacter(PlayerCharacterTemplate template)
        {
            _template = template;
            characterName = template.CharacterName;
            characterStats = template.CharacterStats.Clone();
            level = 1;
            experience = 0;
            SetTargetExperience();
        }

        public void AddExperience(float experienceToAdd)
        {
            experience += experienceToAdd;
            do
            {
                level++;
                experience -= _targetExperience;
                SetTargetExperience();
            } while (experience >= _targetExperience);
        }

        private void SetTargetExperience()
        {
            var targetLevel = ++level;
            _targetExperience = experienceData.GetExperienceCost(targetLevel);
        }
    }
}