using System.Linq;
using UnityEngine;

namespace MightyAdventures.CharacterSystem
{
    [CreateAssetMenu(fileName = "PlayerCharacterExperienceData", menuName = "Mighty Adventures/Character System/Character Experience Data")]
    public class PlayerCharacterExperienceData : ScriptableObject
    {
        [SerializeField] private AnimationCurve experienceCurve;

        public float GetExperienceCost(int level)
        {
            var maxLevel = (int)experienceCurve.keys.Last().time;
            level = Mathf.Clamp(level, 0, maxLevel);
            return experienceCurve.Evaluate(level);
        }
    }
}