using UnityEngine;

namespace ClickyMause.Targets
{
    public class HealerTarget : AbstractTarget
    {
        [SerializeField] private int healValue;

        protected override void TargetActions()
        {
            playerData.CurrentHealth += healValue;
        }
    }
}