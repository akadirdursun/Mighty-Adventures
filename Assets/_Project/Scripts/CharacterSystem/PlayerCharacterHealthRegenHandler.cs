using System.Collections;
using UnityEngine;

namespace MightyAdventures.CharacterSystem
{
    public class PlayerCharacterHealthRegenHandler : MonoBehaviour
    {
        [SerializeField] private PlayerCharacterBehaviour playerCharacterBehaviour;

        private Coroutine _healthRegenCoroutine;

        public void StartHealthRegen()
        {
            StopHealthRegen();
            _healthRegenCoroutine = StartCoroutine(HealthRegenRoutine());
        }

        public void StopHealthRegen()
        {
            if (_healthRegenCoroutine == null) return;
            StopCoroutine(_healthRegenCoroutine);
        }

        private IEnumerator HealthRegenRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                playerCharacterBehaviour.Heal();
            }
        }
    }
}