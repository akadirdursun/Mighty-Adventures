using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace ClickyMause
{
    public class GameManager : MonoBehaviour
    {
        private bool isPaused;

        public void GameOver()
        {
            StaticEvents.GameOver?.Invoke();
        }

        public void RestartGame()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void PauseResumeGame()
        {
            if (isPaused)
            {
                Time.timeScale = 1;
                isPaused = false;
            }
            else
            {
                Time.timeScale = 0;
                isPaused = true;
            }
            StaticEvents.PauseResumeGame?.Invoke();
        }
    
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}