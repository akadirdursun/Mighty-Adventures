using MightyAdventures.StatSystem;
using UnityEngine;

namespace MightyAdventures.CharacterSystem
{
    [CreateAssetMenu(fileName = "PlayerCharacterData", menuName = "Mighty Adventures/Character System/Player Character Data")]
    public class PlayerCharacterData : ScriptableObject
    {
        [SerializeField] private string playerName;
        [SerializeField] private Stats stats;
        private PlayerCharacterTemplate _template;
        public GameObject CharacterPrefab => _template.Prefab;

        public void InitializePlayerCharacter(PlayerCharacterTemplate template)
        {
            _template = template;
            playerName = template.CharacterName;
            stats = template.Stats.Clone();
        }
    }
}