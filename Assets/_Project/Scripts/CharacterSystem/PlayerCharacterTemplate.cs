using MightyAdventures.StatSystem;
using UnityEngine;

namespace MightyAdventures.CharacterSystem
{
    [CreateAssetMenu(fileName = "PlayerCharacterTemplate", menuName = "Mighty Adventures/Character System/Player Character Template")]
    public class PlayerCharacterTemplate : ScriptableObject
    {
        [SerializeField] private string characterName = "Mighty Adventurer";
        [SerializeField] private PlayerCharacterStats playerCharacterStats;
        [SerializeField] private GameObject prefab;
            

        public string CharacterName => characterName;
        public PlayerCharacterStats PlayerCharacterStats => playerCharacterStats;
        public GameObject Prefab => prefab;
    }
}