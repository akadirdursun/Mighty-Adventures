using TMPro;
using UnityEngine;

namespace MightyAdventures.StatSystem.UI
{
    public class RoundStatView: MonoBehaviour
    {
        [SerializeField] private TMP_Text statText;
        private AbstractStat _stat;

        public void Initialize(AbstractStat stat)
        {
            UnregisterFromEvents();
            _stat = stat;
            SetStatText();
            RegisterToEvents();
        }

        private void SetStatText()
        {
            statText.text = $"{_stat.GetValueText()}";
        }

        private void RegisterToEvents()
        {
            if (_stat == null) return;
            _stat.OnStatChanged += SetStatText;
        }

        private void UnregisterFromEvents()
        {
            if (_stat == null) return;

            _stat.OnStatChanged -= SetStatText;
        }

        #region MonoBehaviour Methods

        private void OnDestroy()
        {
            UnregisterFromEvents();
        }

        #endregion
    }
}