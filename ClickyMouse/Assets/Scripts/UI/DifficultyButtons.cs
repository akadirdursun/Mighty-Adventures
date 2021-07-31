using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ClickyMause
{
    public class DifficultyButtons : MonoBehaviour
    {
        [SerializeField] private DifficultySettingsData difficulty;

        private Button difficultyButton;

        private void Start()
        {
            difficultyButton = GetComponent<Button>();
            difficultyButton.onClick.AddListener(SetDifficulty);
        }

        private void SetDifficulty()
        {
            StaticEvents.StartTheGame?.Invoke(difficulty);
        }
    }
}