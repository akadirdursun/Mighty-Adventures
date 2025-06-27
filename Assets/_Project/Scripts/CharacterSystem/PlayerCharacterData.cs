using System;
using MightyAdventures.StatSystem;
using UnityEngine;

namespace MightyAdventures.CharacterSystem
{
    [CreateAssetMenu(fileName = "PlayerCharacterData", menuName = "Mighty Adventures/Character System/Player Character Data")]
    public class PlayerCharacterData : ScriptableObject
    {
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
        public Action OnCharacterInitialized;

        public void InitializePlayerCharacter(float targetExperience)
        {
            characterName = _template.CharacterName;
            stats = _template.PlayerCharacterStats.Clone();
            level = 1;
            experience = 0;
            _targetExperience = targetExperience;
            OnCharacterInitialized?.Invoke();
        }

        public void InitializePlayerCharacter(PlayerCharacterTemplate template, float targetExperience)
        {
            _template = template;
            InitializePlayerCharacter(targetExperience);
        }

        public void LevelUp()
        {
            level++;
        }

        public void SetExperience(float newExperience)
        {
            experience = newExperience;
        }

        public void SetTargetExperience(float newTargetExperience)
        {
            _targetExperience = newTargetExperience;
        }
    }
}