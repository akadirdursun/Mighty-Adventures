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
        [SerializeField] private int experience;
        [SerializeField] private CharacterStats stats;

        public Action OnSpawnedEnemyChanged;

        public string Name => $"{enemyName} (Lv.{enemyLevel})";

        public void Initialize(string eName, int eLevel, int eExperience, CharacterStats eStats)
        {
            enemyName = eName;
            enemyLevel = eLevel;
            experience = eExperience;
            stats = eStats;
            OnSpawnedEnemyChanged?.Invoke();
        }
    }
}