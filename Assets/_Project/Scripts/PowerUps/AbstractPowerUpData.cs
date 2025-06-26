using MightyAdventures.StatSystem;
using UnityEngine;

namespace MightyAdventures.PowerUps
{
    public abstract class AbstractPowerUpData : ScriptableObject
    {
        [SerializeField] protected string statName;
        [SerializeField] protected Color statColor;
        [SerializeField] private Sprite icon;
        public Sprite Icon => icon;

        public abstract void ApplyPowerUp(PlayerCharacterStats stats);
        public abstract string GetDescription();
        protected string GetColorHexCode()
        {
            return ColorUtility.ToHtmlStringRGB(statColor);
        }
    }
}