using UnityEngine;

namespace ClickyMause.Targets
{
    public class BombTarget : AbstractTarget
    {
        [SerializeField] private int damage;

        protected override void TargetActions()
        {
            playerData.CurrentHealth -= damage;
        }
    }
}