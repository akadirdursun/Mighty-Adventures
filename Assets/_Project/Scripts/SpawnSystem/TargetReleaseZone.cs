using MightyAdventures.TargetSystem;
using UnityEngine;

namespace MightyAdventures.SpawnSystem
{
    public class TargetReleaseZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out AbstractTarget target)) return;
            
            target.Disable();
        }
    }
}