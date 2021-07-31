using UnityEngine;
using System;
using System.Collections.Generic;

namespace ClickyMause
{
    public static class StaticEvents
    {
        public delegate void VoidDelegate();
        public static VoidDelegate GameOver;
        //public static VoidDelegate LevelUpDifficulty;
        public static VoidDelegate PauseResumeGame;

        public static Action<DifficultySettingsData> StartTheGame;
        public static Action<bool> Hungry;
        public static Action<float> HungerBoost;
    }
}