using UnityEngine;
using TMPro;
using System.Collections;
using System;

namespace ClickyMause
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timerText;

        private float elapsedTime;
        private int secToLevelUp = 30;
        private bool isPlaying;

        private TimeSpan timePlaying;
        private void OnEnable()
        {
            StaticEvents.StartTheGame += StartTimer;
            StaticEvents.GameOver += StopTimer;
        }

        private void OnDisable()
        {
            StaticEvents.StartTheGame -= StartTimer;
            StaticEvents.GameOver -= StopTimer;
        }

        private void StartTimer(DifficultySettingsData setting)
        {
            elapsedTime = 0;
            isPlaying = true;
            secToLevelUp = setting.SecToLevelUpDifficulty;
            StartCoroutine(TimerCoroutine());
        }

        private void StopTimer()
        {
            isPlaying = false;
        }

        private IEnumerator TimerCoroutine()
        {
            while (isPlaying)
            {
                elapsedTime += Time.deltaTime;
                timePlaying = TimeSpan.FromSeconds(elapsedTime);
                timerText.text = timePlaying.ToString("mm':'ss");
                //if (timePlaying.Seconds % secToLevelUp == 0)
                //    StaticEvents.LevelUpDifficulty?.Invoke();

                yield return null;
            }
        }
    }
}