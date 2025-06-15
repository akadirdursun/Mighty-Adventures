using UnityEngine;

namespace MightyAdventures.GameZone
{
    [CreateAssetMenu(fileName = "GameZoneData", menuName = "Mighty Adventures/Game Zone/Game Zone Data")]
    public class GameZoneData : ScriptableObject
    {
        private Bounds _gameZoneBounds;

        public void SetBounds(Bounds gameZoneBounds)
        {
            _gameZoneBounds = gameZoneBounds;
        }
        public Vector3 GetRandomPositionInBounds(bool useDepth = false)
        {
            var posX = Random.Range(_gameZoneBounds.min.x, _gameZoneBounds.max.x);
            var posY = Random.Range(_gameZoneBounds.min.y, _gameZoneBounds.max.y);
            var posZ = useDepth ? Random.Range(_gameZoneBounds.min.z, _gameZoneBounds.max.z) : _gameZoneBounds.center.z;
            return new Vector3(posX, posY, posZ);
        }
    }
}