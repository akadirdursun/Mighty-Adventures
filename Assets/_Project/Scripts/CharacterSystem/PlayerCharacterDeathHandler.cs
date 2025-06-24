using MightyAdventures.GameStateSystem;
using MightyAdventures.StatSystem;
using UnityEngine;

namespace MightyAdventures.CharacterSystem
{
    public class PlayerCharacterDeathHandler : MonoBehaviour
    {
        [SerializeField] private PlayerCharacterData playerCharacterData;
        [SerializeField] private GameStateData gameStateData;

        private VitalityStat _healthStat;

        private void OnCharacterDied()
        {
            gameStateData.ChangeGameState(GameStates.DefeatState);
        }

        private void SetHealthStat()
        {
            UnregisterFromDeathEvent();
            _healthStat = playerCharacterData.Stats.Health;
            RegisterToDeathEvent();
        }

        private void RegisterToDeathEvent()
        {
            if (_healthStat == null) return;
            _healthStat.OnVitalDropToZero += OnCharacterDied;
        }

        private void UnregisterFromDeathEvent()
        {
            if (_healthStat == null) return;
            _healthStat.OnVitalDropToZero -= OnCharacterDied;
        }

        #region MonoBehaviour Methods

        private void Awake()
        {
            SetHealthStat();
        }

        private void OnEnable()
        {
            playerCharacterData.OnCharacterInitialized += SetHealthStat;
        }

        private void OnDisable()
        {
            playerCharacterData.OnCharacterInitialized -= SetHealthStat;
            UnregisterFromDeathEvent();
        }

        #endregion
    }
}