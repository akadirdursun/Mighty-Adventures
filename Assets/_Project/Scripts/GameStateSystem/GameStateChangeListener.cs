using UnityEngine;
using UnityEngine.Events;

namespace MightyAdventures.GameStateSystem
{
    public class GameStateChangeListener : MonoBehaviour
    {
        [SerializeField] private GameStateData gameStateData;
        [SerializeField] private GameStates listenedGameState;
        [SerializeField, Space] private UnityEvent gameStateEnterResponse;
        [SerializeField, Space] private UnityEvent gameStateExitResponse;

        private void OnStateEnter()
        {
            gameStateEnterResponse?.Invoke();
        }

        private void OnStateExit()
        {
            gameStateExitResponse?.Invoke();
        }

        #region MonoBehaviour Methods

        private void OnEnable()
        {
            var stateInfo = gameStateData.GetStateInfo(listenedGameState);
            stateInfo.OnStateEnter += OnStateEnter;
            stateInfo.OnStateExit += OnStateExit;
        }

        private void OnDisable()
        {
            var stateInfo = gameStateData.GetStateInfo(listenedGameState);
            stateInfo.OnStateEnter -= OnStateEnter;
            stateInfo.OnStateExit -= OnStateExit;
        }

        #endregion
    }
}