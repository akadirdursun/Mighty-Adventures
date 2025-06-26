using UnityEngine;

namespace MightyAdventures.PowerUps.UI
{
    public class PowerUpCardArea : MonoBehaviour
    {
        [SerializeField] private PowerUpDatabase powerUpDatabase;
        [SerializeField] private PowerUpCard[] cards;

        public void Initialize()
        {
            var cardCount = cards.Length;
            var selectedPowerUps = powerUpDatabase.GetRandomPowerUps(cardCount);
            for (int i = 0; i < cardCount; i++)
            {
                cards[i].Initialize(selectedPowerUps[i]);
            }
        }
    }
}