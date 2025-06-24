using System;
using UnityEngine;

namespace MightyAdventures.GameStateSystem
{
    [Serializable]
    public class GameStateInfo
    {
        [SerializeField] private GameStateSystem.GameStates state;
        public Action OnStateEnter;
        public Action OnStateExit;

        public GameStateSystem.GameStates State => state;
    }
}