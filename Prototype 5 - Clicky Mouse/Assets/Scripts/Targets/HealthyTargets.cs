using UnityEngine;

namespace ClickyMause.Targets
{
    public class HealthyTargets : AbstractTarget
    {
        [SerializeField] private int nutritiveValue;
        [SerializeField] [Range(0, 1)] private float healPoint;
        [SerializeField] private GameObject popUpPrefab;

        private bool isHealed = false;

        protected override void TargetActions()
        {
            isHealed = playerData.AddHealPoints(healPoint);
            playerData.CurrentHunger -= nutritiveValue;

            if (isHealed)
                Instantiate(popUpPrefab, transform.position, Quaternion.identity);
        }
    }
}