using MightyAdventures.StatSystem;
using UnityEngine;

namespace MightyAdventures.CharacterSystem
{
    [CreateAssetMenu(fileName = "PlayerCharacterData", menuName = "Mighty Adventures/Character System/Player Character Data")]
    public class PlayerCharacterData : ScriptableObject
    {
        [SerializeField] private string playerName;
        [SerializeField] private CharacterStats characterStats;
        private PlayerCharacterTemplate _template;
        public GameObject CharacterPrefab => _template.Prefab;
        public CharacterStats CharacterStats => characterStats;

        public void InitializePlayerCharacter(PlayerCharacterTemplate template)
        {
            _template = template;
            playerName = template.CharacterName;
            characterStats = template.CharacterStats.Clone();
        }
    }
}