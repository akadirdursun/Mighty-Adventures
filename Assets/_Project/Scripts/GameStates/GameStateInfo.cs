using System;
using UnityEngine;

namespace MightyAdventures.GameStates
{
    [Serializable]
    public class GameStateInfo
    {
        [SerializeField] private GameStates state;
        public Action OnStateEnter;
        public Action OnStateExit;

        public GameStates State => state;
    }
}