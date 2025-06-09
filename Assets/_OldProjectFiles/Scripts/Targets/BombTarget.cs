using UnityEngine;

namespace ClickyMause.Targets
{
    public class BombTarget : AbstractTarget
    {
        [Header("Type Specific Variables")]
        [SerializeField] private int damage;

        protected override void TargetActions()
        {
            playerData.CurrentHealth -= damage;
        }
    }
}