using MightyAdventures.StatSystem;
using UnityEngine;

namespace MightyAdventures.CharacterSystem
{
    [CreateAssetMenu(fileName = "PlayerCharacterData", menuName = "Mighty Adventures/Character System/Player Character Data")]
    public class PlayerCharacterData : ScriptableObject
    {
        [SerializeField] private string playerName;
        [SerializeField] private Stats stats;

        public void InitializePlayerCharacter(PlayerCharacterTemplate template)
        {
            playerName = template.CharacterName;
            stats = template.Stats.Clone();
        }
    }
}