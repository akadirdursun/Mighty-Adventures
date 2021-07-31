using UnityEngine;

namespace ClickyMause.Targets
{
    public class FastFoodTargets : AbstractTarget
    {
        [Header("Type Specific Variables")]
        [SerializeField] private int nutritiveValue;
        [SerializeField] [Range(0.4f, 0.9f)] private float hungerSpeedBoost;

        protected override void TargetActions()
        {
            playerData.CurrentHunger -= nutritiveValue;
            StaticEvents.HungerBoost?.Invoke(hungerSpeedBoost);
        }
    }
}