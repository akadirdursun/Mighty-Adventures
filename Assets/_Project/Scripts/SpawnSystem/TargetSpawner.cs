using System.Collections;
using MightyAdventures.CharacterSystem;
using MightyAdventures.GameZone;
using UnityEngine;

namespace MightyAdventures.SpawnSystem
{
    public class TargetSpawner : MonoBehaviour
    {
        [SerializeField] private PlayerCharacterData playerCharacterData;
        [SerializeField] private GameZoneData gameZoneData;
        [SerializeField] private AbstractTargetPoolManager targetPoolManager;

        private float _spawnTimer;
        private Coroutine _spawnCoroutine;

        public void ActivateTargetSpawner()
        {
            if (_spawnCoroutine != null) return;
            _spawnCoroutine = StartCoroutine(SpawnTargetCoroutine());
        }

        public void DeactivateTargetSpawner()
        {
            if (_spawnCoroutine == null) return;
            StopCoroutine(_spawnCoroutine);
            _spawnCoroutine = null;
        }

        private void SpawnTarget()
        {
            var spawnTokenCunt = playerCharacterData.Stats.MaxSkillTokenCount.Value;
            for (int i = 0; i < spawnTokenCunt; i++)
            {
                var target = targetPoolManager.GetTarget();
                var spawnPos = gameZoneData.GetRandomPositionInBounds();
                target.transform.position = spawnPos;
                target.Enable();
                target.Throw();
            }
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
            _spawnTimer = playerCharacterData.Stats.AttackSpeed.Value;
        }

        #region MonoBehaviour Methods

        private void OnEnable()
        {
            playerCharacterData.OnCharacterLevelChanged += SetSpawnTimer;
        }

        private void Start()
        {
            SetSpawnTimer();
        }

        private void OnDisable()
        {
            playerCharacterData.OnCharacterLevelChanged -= SetSpawnTimer;
        }

        #endregion
    }
}