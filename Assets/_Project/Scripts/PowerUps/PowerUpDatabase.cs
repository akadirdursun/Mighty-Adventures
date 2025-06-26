using MightyAdventures.Utilities;
using UnityEngine;

namespace MightyAdventures.PowerUps
{
    [CreateAssetMenu(fileName = "PowerUpDatabase", menuName = "Mighty Adventures/Power Ups/Power Up Database")]
    public class PowerUpDatabase : ScriptableObject
    {
        [SerializeField] private AbstractPowerUpData[] powerUps;

        public AbstractPowerUpData[] GetRandomPowerUps(int amount)
        {
            return powerUps.Random(amount);
        }
    }
}