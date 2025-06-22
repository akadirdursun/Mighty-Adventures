using System.Linq;
using UnityEngine;

namespace MightyAdventures.GameStateSystem
{
    [CreateAssetMenu(fileName = "GameStateData", menuName = "Mighty Adventures/Game States/Game State Data")]
    public class GameStateData : ScriptableObject
    {
        [SerializeField] private GameStateInfo[] gamesStates;

        private GameStateInfo _currentGameState;

        public void ChangeGameState(GameStateSystem.GameStates newGameState)
        {
            if (_currentGameState != null)
                _currentGameState.OnStateExit?.Invoke();
            _currentGameState = GetStateInfo(newGameState);
            _currentGameState.OnStateEnter?.Invoke();
        }

        public GameStateInfo GetStateInfo(GameStateSystem.GameStates gameState)
        {
            return gamesStates.First(stateInfo => stateInfo.State == gameState);
        }
    }
}