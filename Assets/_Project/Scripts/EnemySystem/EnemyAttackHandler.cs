using System.Collections;
using MightyAdventures.CharacterSystem;
using UnityEngine;

namespace MightyAdventures.EnemySystem
{
    public class EnemyAttackHandler : MonoBehaviour
    {
        [SerializeField] private SpawnedEnemyData spawnedEnemyData;
        [SerializeField] private PlayerCharacterBehaviour playerCharacterBehaviour;

        private Coroutine _attackCoroutine;

        private void StartAttackCoroutine()
        {
            StopAttackCoroutine();
            _attackCoroutine = StartCoroutine(AttackRoutine());
        }

        public void StopAttackCoroutine()
        {
            if(_attackCoroutine==null)return;
            StopCoroutine(_attackCoroutine);
        }

        private IEnumerator AttackRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnedEnemyData.Stats.AttackSpeed.Value);
                playerCharacterBehaviour.Damage(spawnedEnemyData.Stats.Damage.Value);
            }
        }

        #region MonoBehaviour Methods

        private void OnEnable()
        {
            spawnedEnemyData.OnSpawnedEnemyChanged += StartAttackCoroutine;
        }

        private void OnDisable()
        {
            spawnedEnemyData.OnSpawnedEnemyChanged -= StartAttackCoroutine;
        }

        #endregion
    }
}