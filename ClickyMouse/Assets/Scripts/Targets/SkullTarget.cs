using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClickyMause.Targets
{
    public class SkullTarget : AbstractTarget
    {
        [Header("Type Specific Variables")]
        [SerializeField] private int increaseHunger;

        protected override void TargetActions()
        {
            playerData.CurrentHunger += increaseHunger;
        }
    }
}