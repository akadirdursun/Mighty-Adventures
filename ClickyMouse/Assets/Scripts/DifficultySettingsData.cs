using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClickyMause
{
    [CreateAssetMenu(fileName = "NewDifficultySetting", menuName = "Settings/Difficulty Setting")]
    public class DifficultySettingsData : ScriptableObject
    {
        [SerializeField] private int spawnPerSec;
        [SerializeField] private int hungryPerSec;
        [SerializeField] private int damageTakenPerSec;
        [SerializeField] private int secToLevelUpDifficulty;

        public int SpawnTime { get => spawnPerSec; }
        public int HungryPerSec { get => hungryPerSec; }
        public int DamageTakenPerSec { get => damageTakenPerSec; }
        public int SecToLevelUpDifficulty { get => secToLevelUpDifficulty; }
    }
}