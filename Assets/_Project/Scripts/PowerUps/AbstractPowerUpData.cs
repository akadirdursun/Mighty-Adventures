using MightyAdventures.StatSystem;
using UnityEngine;

namespace MightyAdventures.PowerUps
{
    public abstract class AbstractPowerUpData : ScriptableObject
    {
        [SerializeField] private Sprite icon;
        public Sprite Icon => icon;

        public abstract void ApplyPowerUp(PlayerCharacterStats stats);
        public abstract string GetDescription();
    }
}