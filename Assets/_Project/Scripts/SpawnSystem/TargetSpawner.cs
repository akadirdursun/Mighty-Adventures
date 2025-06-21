using System.Collections;
using System.Linq;
using MightyAdventures.CharacterSystem;
using MightyAdventures.GameZone;
using UnityEngine;

namespace MightyAdventures.SpawnSystem
{
    public class TargetSpawner : MonoBehaviour
    {
        [SerializeField] private PlayerCharacterData playerCharacterData;
        [SerializeField] private GameZoneData gameZoneData;
        [SerializeField] private AnimationCurve spawnTargetTimeCurve;
        private ObjectPoolManager _objectPoolManager;

        private float _spawnTimer;

        private void SpawnTarget()
        {
            var target = _objectPoolManager.GetRandomTarget();
            var spawnPos = gameZoneData.GetRandomPositionInBounds();
            target.transform.position = spawnPos;
            target.Enable();
            target.Throw();
        }

        private IEnumerator SpawnTargetCoroutine()
        {
            while (true)
            {
                SpawnTarget();
                yield return new WaitForSeconds(_spawnTimer);
            }
        }

        private void SetSpawnTimer()
        {
            var maxTime = spawnTargetTimeCurve.keys.Last().time;
            var time = Mathf.Clamp(playerCharacterData.Level, 0, maxTime);
            _spawnTimer = spawnTargetTimeCurve.Evaluate(time);
        }

        #region MonoBehaviour Methods

        private void OnEnable()
        {
            playerCharacterData.OnCharacterLevelChanged += SetSpawnTimer;
        }

        private void Start()
        {
            _objectPoolManager = ObjectPoolManager.Instance;
            SetSpawnTimer();
        }

        private void OnDisable()
        {
            playerCharacterData.OnCharacterLevelChanged -= SetSpawnTimer;
        }

        #endregion
    }
}