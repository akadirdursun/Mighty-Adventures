using UnityEngine;

namespace MightyAdventures.GameZone
{
    [CreateAssetMenu(fileName = "GameZoneData", menuName = "Mighty Adventures/Game Zone/Game Zone Data")]
    public class GameZoneData : ScriptableObject
    {
        public Bounds GameZoneBounds { get; set; }
    }
}