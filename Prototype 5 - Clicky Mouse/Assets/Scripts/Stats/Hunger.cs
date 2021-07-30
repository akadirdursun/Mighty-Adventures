using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ClickyMause.Stats
{
    public class Hunger : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;
        [Header("UI")]
        [SerializeField] private Slider hungerSlider;
        [SerializeField] private TextMeshProUGUI hungerValueText;

        private float hungerDelay;
        private bool isHungry = false;
        private bool isHungerBoosted = false;

        private Coroutine hungerCoroutine;

        private void OnEnable()
        {
            StaticEvents.StartTheGame += StartTheHunger;
            StaticEvents.Hungry += ResumeTheHunger;
            StaticEvents.HungerBoost += BoostHunger;
        }

        private void OnDisable()
        {
            StaticEvents.StartTheGame -= StartTheHunger;
            StaticEvents.Hungry -= ResumeTheHunger;
            StaticEvents.HungerBoost -= BoostHunger;
        }

        private void StartTheHunger(DifficultySettingsData settings)
        {
            hungerSlider.maxValue = playerData.MaxHunger;
            hungerDelay = 1f / settings.HungryPerSec;
            StartCoroutine(IncreaseHunger());
        }

        private void ResumeTheHunger(bool hungry)
        {
            isHungry = hungry;
            if (!isHungry)
                StartCoroutine(IncreaseHunger());
        }

        private void BoostHunger(float boostValue)
        {
            float normalSpeed = hungerDelay;

            if (isHungerBoosted)
            {
                StopCoroutine(hungerCoroutine);
                hungerDelay = normalSpeed;
            }

            hungerCoroutine = StartCoroutine(SetHungerBoost(boostValue, normalSpeed));
        }

        IEnumerator SetHungerBoost(float hungerBoost, float normalSpeed)
        {
            isHungerBoosted = true;
            hungerDelay *= hungerBoost;
            yield return new WaitForSeconds(0.3f);
            hungerDelay = normalSpeed;
            isHungerBoosted = false;
        }

        IEnumerator IncreaseHunger()
        {
            while (!isHungry)
            {
                yield return new WaitForSeconds(hungerDelay);
                playerData.CurrentHunger++;
                hungerSlider.value = playerData.CurrentHunger;
                hungerValueText.text = playerData.CurrentHunger + " / " + playerData.MaxHunger;
            }
        }
    }
}