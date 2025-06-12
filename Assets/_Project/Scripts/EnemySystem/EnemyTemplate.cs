using System;
using System.Linq;
using MightyAdventures.StatSystem;
using UnityEngine;

namespace MightyAdventures.EnemySystem
{
    [CreateAssetMenu(fileName = "NewEnemyTemplate", menuName = "Mighty Adventures/Enemy System/Enemy Template")]
    public class EnemyTemplate : ScriptableObject
    {
        [SerializeField] private string enemyName;
        [SerializeField] private GameObject prefab;
        [SerializeField] private EnemyLevelInfo[] levelInfoArray;

        public bool TryGetLevelInfo(int level, out EnemyLevelInfo levelInfo)
        {
            EnemyLevelInfo tempLevelInfo = new EnemyLevelInfo();
            var isAvailable = levelInfoArray.Any(info =>
            {
                var available = info.level == level;
                if (available)
                    tempLevelInfo = info;
                return available;
            });
            levelInfo = tempLevelInfo;
            return isAvailable;
        }

        public bool IsLevelAvailable(int level)
        {
            return levelInfoArray.Any(info => info.level == level);
        }
    }

    [Serializable]
    public struct EnemyLevelInfo
    {
        public int level;
        public CharacterStats stats;
        public int experience;
    }
}