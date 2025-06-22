using MightyAdventures.CharacterSystem;
using MightyAdventures.StatSystem;
using UnityEngine;

namespace MightyAdventures.HUD
{
    public class PlayerCharacterInfoAreaController : AbstractCharacterInfoAreaController
    {
        [SerializeField, Space] private PlayerCharacterData playerCharacterData;
        
        protected override CharacterStats GetCharacterStats()
        {
            return playerCharacterData.CharacterStats;
        }

        protected override string GetCharacterName()
        {
            return playerCharacterData.Name;
        }

        #region MonoBehaviour Methods

        private void Start()
        {
            Initialize();
        }

        #endregion
    }
}