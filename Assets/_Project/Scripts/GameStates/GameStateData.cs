using System.Linq;
using UnityEngine;

namespace MightyAdventures.GameStates
{
    [CreateAssetMenu(fileName = "GameStateData", menuName = "Mighty Adventures/Game States/Game State Data")]
    public class GameStateData : ScriptableObject
    {
        [SerializeField] private GameStateInfo[] gamesStates;

        private GameStateInfo _currentGameState;

        public void ChangeGameState(GameStates newGameState)
        {
            if (_currentGameState != null)
                _currentGameState.OnStateExit?.Invoke();
            _currentGameState = GetStateInfo(newGameState);
            _currentGameState.OnStateEnter?.Invoke();
        }

        public GameStateInfo GetStateInfo(GameStates gameState)
        {
            return gamesStates.First(stateInfo => stateInfo.State == gameState);
        }
    }
}