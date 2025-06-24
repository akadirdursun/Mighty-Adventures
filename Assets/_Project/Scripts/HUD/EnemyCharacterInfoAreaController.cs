using MightyAdventures.EnemySystem;
using MightyAdventures.StatSystem.UI;
using TMPro;
using UnityEngine;

namespace MightyAdventures.HUD
{
    public class EnemyCharacterInfoAreaController : MonoBehaviour
    {
        [SerializeField, Space] private SpawnedEnemyData spawnedEnemyData;
        [SerializeField] private TMP_Text nameText;
        [Header("Stat Views")]
        [SerializeField] private VitalStatView healthView;
        [SerializeField] private RoundStatView damageView;
        [SerializeField] private RoundStatView damageResistanceView;
        [SerializeField] private StatTextView attackSpeedView;
        [SerializeField] private StatTextView trapSpawnChanceView;
        [SerializeField] private StatTextView maxTrapSpawnCountView;

        protected void Initialize()
        {
            nameText.text = spawnedEnemyData.Name;
            var enemyStats = spawnedEnemyData.Stats;
            healthView.Initialize(enemyStats.Health);
            damageView.Initialize(enemyStats.Damage);
            damageResistanceView.Initialize(enemyStats.DamageResistance);
            attackSpeedView.Initialize("Attack Speed", enemyStats.AttackSpeed, "s");
            trapSpawnChanceView.Initialize("Trap Spawn Chance", enemyStats.TrapSpawnChance, "/s");
            maxTrapSpawnCountView.Initialize("Trap Count", enemyStats.MaxTrapSpawnCount);
        }

        private void OnNewEnemySpawned()
        {
            Initialize();
        }

        #region MonoBehaviour Methods

        private void OnEnable()
        {
            spawnedEnemyData.OnSpawnedEnemyChanged += OnNewEnemySpawned;
        }

        private void OnDisable()
        {
            spawnedEnemyData.OnSpawnedEnemyChanged -= OnNewEnemySpawned;
        }

        #endregion
    }
}