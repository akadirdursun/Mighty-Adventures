using UnityEngine;
using System.Collections;

namespace ClickyMause.Stats
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;

        private int damageTakenPerSec = 1;

        private bool isHungry;

        private Coroutine takeDamageCoroutine;

        private void OnEnable()
        {
            StaticEvents.Hungry += TakeDamage;
            StaticEvents.StartTheGame += SetDifficulty;
        }

        private void OnDisable()
        {
            StaticEvents.Hungry -= TakeDamage;
            StaticEvents.StartTheGame -= SetDifficulty;
        }

        private void SetDifficulty(DifficultySettingsData difficulty)
        {
            damageTakenPerSec = difficulty.DamageTakenPerSec;
        }

        private void TakeDamage(bool IsHungry)
        {
            isHungry = IsHungry;

            if (IsHungry)
                takeDamageCoroutine = StartCoroutine(TakeDamageOverTime());
        }

        IEnumerator TakeDamageOverTime()
        {
            while (isHungry)
            {
                yield return new WaitForSeconds(1f / damageTakenPerSec);
                playerData.CurrentHealth--;

                if (playerData.CurrentHealth <= 0)
                {
                    StaticEvents.GameOver?.Invoke();
                    StopCoroutine(takeDamageCoroutine);
                }
            }
        }
    }
}