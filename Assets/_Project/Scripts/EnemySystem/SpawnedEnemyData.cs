using System;
using MightyAdventures.StatSystem;
using UnityEngine;

namespace MightyAdventures.EnemySystem
{
    [CreateAssetMenu(fileName = "SpawnedEnemyData", menuName = "Mighty Adventures/Enemy System/Spawned Enemy Data")]
    public class SpawnedEnemyData : ScriptableObject
    {
        [SerializeField] private string enemyName;
        [SerializeField] private int enemyLevel;
        [SerializeField] private float experience;
        [SerializeField] private CharacterStats stats;

        public Action OnSpawnedEnemyChanged;

        public GameObject Prefab { get; private set; }

        public bool IsAlive => stats.Health.Value > 0;
        public string Name => $"{enemyName} (Lv.{enemyLevel})";
        public float Experience => experience;
        public CharacterStats Stats => stats;

        public void Initialize(string eName, int eLevel, float eExperience, CharacterStats eStats, GameObject ePrefab)
        {
            enemyName = eName;
            enemyLevel = eLevel;
            experience = eExperience;
            stats = eStats;
            Prefab = ePrefab;
            OnSpawnedEnemyChanged?.Invoke();
        }

        public void Damage(float damage)
        {
            stats.Health.DecreaseCurrentValue(damage);
        }
    }
}