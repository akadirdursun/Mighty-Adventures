using UnityEngine;

namespace ClickyMause.Targets
{
    public class HealerTarget : AbstractTarget
    {
        [Header("Type Specific Variables")]
        [SerializeField] private int healValue;

        protected override void TargetActions()
        {
            playerData.CurrentHealth += healValue;
        }
    }
}