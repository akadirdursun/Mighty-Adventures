using MightyAdventures.StatSystem;
using UnityEngine;

namespace MightyAdventures.CharacterSystem
{
    [CreateAssetMenu(fileName = "PlayerCharacterData", menuName = "Mighty Adventures/Character System/Player Character Data")]
    public class PlayerCharacterData : ScriptableObject
    {
        [SerializeField] private string characterName;
        [SerializeField] private int level = 1;
        [SerializeField] private int experience;
        [SerializeField] private CharacterStats characterStats;
        private PlayerCharacterTemplate _template;
        private int _targetExperience;
        public string Name => characterName;
        public int Level => level;
        public GameObject CharacterPrefab => _template.Prefab;
        public CharacterStats CharacterStats => characterStats;

        public void InitializePlayerCharacter(PlayerCharacterTemplate template)
        {
            _template = template;
            characterName = template.CharacterName;
            characterStats = template.CharacterStats.Clone();
            level = 1;
            experience = 0;
            //TODO: Set target experience
        }

        public void AddExperience(int experienceToAdd)
        {
            experience += experienceToAdd;
            if (experience >= _targetExperience)
            {
                level++;
                //TODO: Set new target experience
            }
        }
    }
}